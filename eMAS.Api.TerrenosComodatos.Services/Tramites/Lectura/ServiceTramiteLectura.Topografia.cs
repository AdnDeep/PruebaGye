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

        public ResultadoDTO<TopografiaTerrenoEditViewMoel> ConsultarTopografiaPorId(short id)
        {
            var parametros = $"ServiceTramiteLectura Service Layer Try: id {id}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ConsultarOficioPorId" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };

            ResultadoDTO<TopografiaTerrenoEditViewMoel> resultadoVista = new ResultadoDTO<TopografiaTerrenoEditViewMoel>();
            Tuple<SmcTopografiaTerrenoEdit, string, short> respuestaLogic = null;

            try
            {
                respuestaLogic = _tramiteLogicLectura.GetTopografiaTerrenoPorId(id);
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

            bool respuestaValidacion = _validadoresTramites
                                            .ResultadoLogicConsultaTopografiaPorId(ref respuestaLogic, ref resultadoVista);

            if (!respuestaValidacion)
            {
                resultadoVista.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }
            var _topografiaTramiteEdit = respuestaLogic.Item1;
            _mapeadoresLectura.MapearSmcTopografiaTramiteEditATopografiaTramiteEditViewModel(ref _topografiaTramiteEdit, ref resultadoVista);

            return resultadoVista;
        }

        public ResultadoDTO<List<TopografiaTerrenoListViewMoel>> ConsultarTopografiasPorIdTramite(short idTramite)
        {
            var parametros = $"ServiceTramiteLectura Service Layer Try: idTramite {idTramite}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ConsultarTopografiasPorIdTramite" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };

            ResultadoDTO<List<TopografiaTerrenoListViewMoel>> resultadoVista = new ResultadoDTO<List<TopografiaTerrenoListViewMoel>>();

            Tuple<List<SmcTopografiaTerrenoEdit>, string> resultadoLogic = null;
            try
            {
                resultadoLogic = _tramiteLogicLectura
                                        .GetTopografiaTerrenoPorIdTramite(idTramite);
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

            bool validaRespuestaLogic = _validadoresTramites.ResultadoLogicConsultaTopografiaPorIdTramite(ref resultadoLogic, ref resultadoVista);

            if (!validaRespuestaLogic)
            {
                resultadoVista.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }

            List<SmcTopografiaTerrenoEdit> lsOficioTramite = resultadoLogic.Item1;
            _mapeadoresLectura
                .MapearListaTopografiaTramiteEditATopografiaTramiteListViewModel(ref lsOficioTramite
                , ref resultadoVista);

            return resultadoVista;
        }

        
    }
}
