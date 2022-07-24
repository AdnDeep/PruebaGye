using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresTramite
    {
        private readonly ILogger<ValidadoresTramite> _logger;
        public ValidadoresTramite(ILogger<ValidadoresTramite> logger)
        {
            _logger = logger;
        }
        public bool InputClientReportGetPorId(short id
            , ref TramiteReportClientViewModel salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "InputClientReportGetPorId" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            if (id <= 0)
            {
                salida.mensaje = "Input Request Incorrecta, el objeto está vacío Id";
                salida.canContinue = false;
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool InputClientGetPorIdGeneric<T>(short id
            , ref ResultadoDTO<T> salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "InputClientGetPorIdGeneric" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            if (id < 0)
            {
                salida.mensaje = "Input Request Incorrecta, el objeto está vacío Id";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool InputClientGetPorId(short id
            , ref ResultadoDTO<TramiteEditViewModel> salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "InputClientGetPorId" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            salida.dataresult = new TramiteEditViewModel();
            if (id < 0)
            {
                salida.mensaje = "Input Request Incorrecta, el objeto está vacío Id";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            
            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool InputClientGetPagedData(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila
            , ref ResultadoDTO<DataPagineada<TramiteListViewModel>> salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "InputClientGetPagedData" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            salida.dataresult = new DataPagineada<TramiteListViewModel>();
            if (string.IsNullOrEmpty(panelFilter) || string.IsNullOrWhiteSpace(panelFilter))
            {
                salida.mensaje = "Input Request Incorrecta, el objeto está vacío panelFilter";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            try
            {
                var panelModel = JsonConvert.DeserializeObject<TramitePanelFilterViewModel>(panelFilter);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Input Request Incorrecta, el objeto Panel Filter no es correcto. Excepcion {ex.Message}");
                }
                salida.mensaje = "Se produjo un error en el aplicativo (1).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (string.IsNullOrEmpty(resultContainer) || string.IsNullOrWhiteSpace(resultContainer))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Input Request Incorrecta, el objeto está vacío resultContainer");
                }
                salida.mensaje = "Se produjo un error en el aplicativo (2).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
