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
        public ResultadoDTO<OficioTramiteEditViewModel> ConsultarOficioPorId(short id)
        {
            var parametros = $"ServiceTramiteLectura Service Layer Try: id {id}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ConsultarOficioPorId" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };

            ResultadoDTO<OficioTramiteEditViewModel> resultadoVista = new ResultadoDTO<OficioTramiteEditViewModel>();
            Tuple<SmcOficioOtrasDireccioneEdit, string, short> respuestaLogic = null;

            try
            {
                respuestaLogic = _tramiteLogicLectura.GetSeguimientoOficioPorId(id);
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
                                            .ResultadoLogicConsultaOficioPorId(ref respuestaLogic, ref resultadoVista);

            if (!respuestaValidacion)
            {
                resultadoVista.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }
            var _oficioTramiteEdit = respuestaLogic.Item1;
            _mapeadoresLectura.MapearSmcOficioTramiteEditAOficioTramiteEditViewModel(ref _oficioTramiteEdit, ref resultadoVista);

            return resultadoVista;
        }

        public ResultadoDTO<List<OficioTramiteListViewModel>> ConsultarOficiosPorIdTramite(short idTramite)
        {
            var parametros = $"ServiceTramiteLectura Service Layer Try: idTramite {idTramite}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ConsultarOficiosPorIdTramite" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };

            ResultadoDTO<List<OficioTramiteListViewModel>> resultadoVista = new ResultadoDTO<List<OficioTramiteListViewModel>>();

            Tuple<List<SmcOficioOtrasDireccioneEdit>, string> resultadoLogic = null;
            try
            {
                resultadoLogic = _tramiteLogicLectura
                                        .GetSeguimientoOficioPorIdTramite(idTramite);
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

            bool validaRespuestaLogic = _validadoresTramites.ResultadoLogicConsultaOficioPorIdTramite(ref resultadoLogic, ref resultadoVista);

            if (!validaRespuestaLogic)
            {
                resultadoVista.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }

            List<SmcOficioOtrasDireccioneEdit> lsOficioTramite = resultadoLogic.Item1;
            _mapeadoresLectura
                .MapearListaOficioTramiteEditAOficioTramiteListViewModel(ref lsOficioTramite
                , ref resultadoVista);

            return resultadoVista;
        }

    }
}
