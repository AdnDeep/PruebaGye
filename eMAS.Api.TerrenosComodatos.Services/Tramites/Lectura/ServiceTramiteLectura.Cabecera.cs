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
        public ResultadoDTO<TramiteEditViewModel> ConsultarPorId(short id)
        {
            var parametros = $"ServiceTramiteLectura Service Layer Try: id {id}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ConsultarPorId" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };

            ResultadoDTO<TramiteEditViewModel> resultadoVista = new ResultadoDTO<TramiteEditViewModel>();
            Tuple<SmcTramiteEdit, string, short> respuestaLogic = null;

            try
            {
                respuestaLogic = _tramiteLogicLectura.ObtenerTramitePorId(id);
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

            bool respuestaValidacion = _validadoresTramites.ResultadoLogicConsultaPorId(ref respuestaLogic, ref resultadoVista);

            if (!respuestaValidacion)
            {
                resultadoVista.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }
            var _tramiteEdit = respuestaLogic.Item1;
            _mapeadoresLectura.MapearSmcTramiteEditATramiteEditViewModel(ref _tramiteEdit, ref resultadoVista);

            return resultadoVista;
        }

        public ResultadoDTO<DataPagineada<TramitesListViewModel>> ConsultarTramitesTodosPaginado(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila)
        {
            ResultadoDTO<DataPagineada<TramitesListViewModel>> resultadoVista = new ResultadoDTO<DataPagineada<TramitesListViewModel>>();
            var parametros = $"ServiceTramiteLectura Service Layer Try: dataPanel {panelFilter}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ConsultarTramitesTodosPaginado" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };

            var panelModel = JsonConvert.DeserializeObject<TramitesPanelFilterModel>(panelFilter);

            Tuple<List<SmcTramitePaginado>, int> resultadoPaginado = null;
            resultadoVista.dataresult = new DataPagineada<TramitesListViewModel>();

            try
            {
                resultadoPaginado = _tramiteLogicLectura
                                        .ObtenerTramitesPaginado(panelModel, numeroPagina, numeroFila);
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

            bool respuestaValidacion = _validadoresTramites.ResultadoLogicConsultaPaginado(ref resultadoPaginado, ref resultadoVista);

            if (!respuestaValidacion)
            {
                resultadoVista.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                resultadoVista.tipo = "ADVERTENCIA";
                return resultadoVista;
            }

            List<SmcTramitePaginado> lsTramitePaginado = resultadoPaginado.Item1;
            _mapeadoresLectura.MapearListaTramitePaginadaAListaTramiteViewModel(ref lsTramitePaginado
                , ref resultadoVista, numeroPagina, resultadoPaginado.Item2, resultContainer);

            return resultadoVista;
        }

    }
}
