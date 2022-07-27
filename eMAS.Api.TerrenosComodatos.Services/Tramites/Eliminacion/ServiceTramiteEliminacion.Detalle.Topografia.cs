using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ServiceTramiteEliminacion : IServiceTramiteEliminacion
    {
        public ResultadoDTO<int> EliminarTopografia(short idTopografiaTramite, string usuario, string controlador, string pcclient)
        {
            var parametros = $"ServiceTramiteEscritura Service Layer Try: Modelo {idTopografiaTramite}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "EliminarTopografia" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            SmcTopografiaTerreno _topografiaTramiteEntidad = new SmcTopografiaTerreno();

            _mapeadores
                .MapearTramiteTopografiaEditViewModelASmcTopografiaTerreno(idTopografiaTramite, ref _topografiaTramiteEntidad, usuario, controlador, pcclient);

            Tuple<short, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logic.EliminarTopografiaTerreno(_topografiaTramiteEntidad);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }

                resultadoVista.mensaje = "Se produjo un error en la aplicación [2]. Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }

            bool respuestaGestionGrabar = _validadores
                                                .ValidarRespuestaServidorTramiteTopografiaAccionAEliminar(ref respuestaLogicDB, ref resultadoVista);

            return resultadoVista;
        }
    }
}
