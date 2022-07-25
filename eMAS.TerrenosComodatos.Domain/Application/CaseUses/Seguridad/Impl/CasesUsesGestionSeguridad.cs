using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionSeguridad : ICasesUsesGestionSeguridad
    {
        private readonly IGestionRepositorioExternoSeguridad _repositorioExterno;
        private readonly ValidadoresSeguridad _validadores;
        private readonly MapeadoresSeguridad _mapeadores;
        private readonly ILogger<CasesUsesGestionSeguridad> _logger;
        public CasesUsesGestionSeguridad(ILogger<CasesUsesGestionSeguridad> logger
            , MapeadoresSeguridad mapeadores
            , ValidadoresSeguridad validadores
            , IGestionRepositorioExternoSeguridad repositorioExterno)
        {
            _repositorioExterno = repositorioExterno;
            _validadores = validadores;
            _mapeadores = mapeadores;
            _logger = logger;
        }
        public bool ValidarPermisoControlador(string user, string controlador)
        {
            return true;
        }

        public string ObtenerPermisosPorUsuario(string user, string controlador)
        {
            string respuesta = "N";
            string _userTmp = "";
            try
            {
                _userTmp = user.Split("@")[0];
            }
            catch (Exception)
            {
                _userTmp = "";
            }
            bool res = _validadores.InputUserController(_userTmp, controlador);

            if (!res)
                return respuesta;

            var resServ = _repositorioExterno.ObtenerPermisoPorUsuario(_userTmp, controlador);

            var resSerVal = _validadores.RespuestaServidor(ref resServ);
            
            if (!resSerVal)
                return respuesta;

            if (resServ.Ok)
                respuesta = "S";

            return respuesta;
        }
    }
}
