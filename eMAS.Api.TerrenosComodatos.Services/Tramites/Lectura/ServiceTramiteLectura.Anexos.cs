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

        public ResultadoDTO<AnexoTramiteEditViewModel> ConsultarAnexoPorId(short id)
        {
            var parametros = $"ServiceTramiteLectura Service Layer Try: id {id}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ConsultarAnexoPorId" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };

            ResultadoDTO<AnexoTramiteEditViewModel> resultadoVista = new ResultadoDTO<AnexoTramiteEditViewModel>();
            Tuple<SmcAnexoTramiteEdit, string, short> respuestaLogic = null;

            try
            {
                respuestaLogic = _tramiteLogicLectura.GetAnexoPorId(id);
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

            bool respuestaValidacion = _validadoresTramites.ResultadoLogicConsultaAnexoPorId(ref respuestaLogic, ref resultadoVista);

            if (!respuestaValidacion)
            {
                resultadoVista.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }
            var _anexoTramiteEdit = respuestaLogic.Item1;
            _mapeadoresLectura.MapearSmcAnexoTramiteEditAAnexoTramiteEditViewModel(ref _anexoTramiteEdit, ref resultadoVista);

            return resultadoVista;
        }

        public ResultadoDTO<List<AnexoTramiteListViewModel>> ConsultarAnexosPorIdTramite(short idTramite)
        {
            var parametros = $"ServiceTramiteLectura Service Layer Try: idTramite {idTramite}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ConsultarAnexosPorIdTramite" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };

            ResultadoDTO<List<AnexoTramiteListViewModel>> resultadoVista = new ResultadoDTO<List<AnexoTramiteListViewModel>>();

            Tuple<List<SmcAnexoTramiteEdit>, string> resultadoLogic = null;
            try
            {
                resultadoLogic = _tramiteLogicLectura
                                        .GetAnexosPorIdTramite(idTramite);
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

            bool validaRespuestaLogic = _validadoresTramites.ResultadoLogicConsultaAnexoPorIdTramite(ref resultadoLogic, ref resultadoVista);

            if (!validaRespuestaLogic)
            {
                resultadoVista.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }

            List<SmcAnexoTramiteEdit> lsAnexoTramite = resultadoLogic.Item1;
            _mapeadoresLectura
                .MapearListaAnexoTramiteEditAAnexoTramiteListViewModel(ref lsAnexoTramite
                , ref resultadoVista);

            return resultadoVista;
        }
    }
}
