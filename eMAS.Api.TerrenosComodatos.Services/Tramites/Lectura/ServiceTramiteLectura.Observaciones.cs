using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ServiceTramiteLectura : IServiceTramiteLectura
    {
        public ResultadoDTO<List<ObservacionTramiteListViewModel>> ConsultarObservacionesPorIdTramite(short idTramite)
        {
            var parametros = $"ServiceTramiteLectura Service Layer Try: idTramite {idTramite}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ConsultarObservacionesPorIdTramite" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };

            ResultadoDTO<List<ObservacionTramiteListViewModel>> resultadoVista = new ResultadoDTO<List<ObservacionTramiteListViewModel>>();

            Tuple<List<SmcTramitesDescEdit>, string> resultadoLogic = null;
            try
            {
                resultadoLogic = _tramiteLogicLectura
                                        .GetObservacionsPorIdTramite(idTramite);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }

                resultadoVista.mensaje = "Se produjo un error en la aplicación [1]. Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }

            bool validaRespuestaLogic = _validadoresTramites.ResultadoLogicConsultaObservacionesPorIdTramite(ref resultadoLogic, ref resultadoVista);

            if (!validaRespuestaLogic)
            {
                resultadoVista.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }

            List<SmcTramitesDescEdit> lsObservacionTramite = resultadoLogic.Item1;
            _mapeadoresLectura
                .MapearListaObservacionTramiteEditAObservacionTramiteListViewModel(ref lsObservacionTramite
                , ref resultadoVista);

            return resultadoVista;
        }

        public ResultadoDTO<ObservacionTramiteEditViewModel> ConsultarObservacionPorId(short id)
        {
            var parametros = $"ServiceTramiteLectura Service Layer Try: id {id}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ConsultarAnexoPorId" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };

            ResultadoDTO<ObservacionTramiteEditViewModel> resultadoVista = new ResultadoDTO<ObservacionTramiteEditViewModel>();
            Tuple<SmcTramitesDescEdit, string, short> respuestaLogic = null;

            try
            {
                respuestaLogic = _tramiteLogicLectura.GetObservacionPorId(id);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error {ex.Message}");
                }

                resultadoVista.mensaje = "Se produjo un error en la aplicación [1]. Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }

            bool respuestaValidacion = _validadoresTramites.ResultadoLogicConsultaObservacionPorId(ref respuestaLogic, ref resultadoVista);

            if (!respuestaValidacion)
            {
                resultadoVista.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }
            var _observacionTramiteEdit = respuestaLogic.Item1;
            _mapeadoresLectura.MapearSmcObservacionTramiteEditAObservacionTramiteEditViewModel(ref _observacionTramiteEdit, ref resultadoVista);

            return resultadoVista;
        }

    }
}
