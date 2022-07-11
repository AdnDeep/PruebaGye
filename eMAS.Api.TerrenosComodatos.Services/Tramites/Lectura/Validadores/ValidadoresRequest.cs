using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public class ValidadoresTramitesRequest
    {
        private readonly ILogger<ValidadoresTramitesRequest> _logger;
        public ValidadoresTramitesRequest(ILogger<ValidadoresTramitesRequest> logger)
        {
            _logger = logger;
        }
        public bool ValidaDataRequestLecturaTodosPaginado(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila, ref ResultadoDTO<DataPagineada<TramitesListViewModel>> salida)
        {
            bool puedeContinuar = false;
            salida.dataresult = new DataPagineada<TramitesListViewModel>();
            if (string.IsNullOrEmpty(panelFilter) || string.IsNullOrWhiteSpace(panelFilter))
            {
                salida.mensaje = "Input Request Incorrecta, el objeto está vacío panelFilter";
                salida.tipo = "ERROR";
                return puedeContinuar;
            }

            try
            {
                var panelModel = JsonConvert.DeserializeObject<TramitesPanelFilterModel>(panelFilter);
            }
            catch (Exception ex)
            {
                salida.mensaje = $"Input Request Incorrecta, el objeto Panel Filter no es correcto. Excepcion {ex.Message}";
                salida.tipo = "ERROR";
                return puedeContinuar;
            }

            if (string.IsNullOrEmpty(resultContainer) || string.IsNullOrWhiteSpace(resultContainer))
            {
                salida.mensaje = "Input Request Incorrecta, el objeto está vacío resultContainer";
                salida.tipo = "ERROR";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }

    }
}
