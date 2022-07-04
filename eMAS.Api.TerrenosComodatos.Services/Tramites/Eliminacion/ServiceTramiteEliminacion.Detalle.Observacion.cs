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
        public ResultadoDTO<int> EliminarObservacion(short idObservacionTramite, string usuario, string controlador, string pcclient)
        {
            var parametros = $"ServiceTramiteEscritura Service Layer Try: Modelo {idObservacionTramite}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "EliminarObservacion" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            ResultadoDTO<int> resultadoVista = new ResultadoDTO<int>();

            SmcTramitesDesc _observacionTramiteEntidad = new SmcTramitesDesc();

            _mapeadores
                .MapearTramiteObservacionEditViewModelASmcTramitesDesc(idObservacionTramite, ref _observacionTramiteEntidad, usuario, controlador, pcclient);

            Tuple<short, string> respuestaLogicDB = null;
            try
            {
                respuestaLogicDB = _logic.EliminarObservacion(_observacionTramiteEntidad);
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
                                                .ValidarRespuestaServidorTramiteObservacionAccionAEliminar(ref respuestaLogicDB, ref resultadoVista);

            return resultadoVista;
        }
    }
}
