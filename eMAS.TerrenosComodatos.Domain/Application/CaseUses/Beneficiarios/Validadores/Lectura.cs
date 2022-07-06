
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresBeneficiario
    {
        private readonly ILogger<ValidadoresBeneficiario> _logger;
        public ValidadoresBeneficiario(ILogger<ValidadoresBeneficiario> logger)
        {
            _logger = logger;
        }
        public bool InputClientGetPagedData(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila, ref ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresBeneficiario Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "InputClientGetPagedData" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            salida.dataresult = new DataPagineada<BeneficiarioListViewModel>();
            if (string.IsNullOrEmpty(panelFilter) || string.IsNullOrWhiteSpace(panelFilter))
            {
                salida.mensaje = "Input Request Incorrecta, el objeto está vacío panelFilter";
                salida.tipo = "ERROR";
                return puedeContinuar;
            }
            try
            {
                var panelModel = JsonConvert.DeserializeObject<BeneficiarioPanelFilterViewModel>(panelFilter);
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
                salida.mensaje = "Se produjo un error en el aplicativo (1).";
                salida.tipo = "ERROR";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
