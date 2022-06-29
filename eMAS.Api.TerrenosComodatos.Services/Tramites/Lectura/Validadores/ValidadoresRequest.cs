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
                var panelModel = JsonConvert.DeserializeObject<TramitesListViewModel>(panelFilter);
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

        //public bool ValidarDatosClienteBeneficiarioEditViewModel(ref BeneficiarioEditViewModel entrada
        //    , string usuario, string controlador, string pcclient
        //    , ref ResultadoDTO<BeneficiarioEditViewModel> salida)
        //{
        //    bool puedeContinuar = false;
        //    salida.mensaje = "OK";
        //    salida.tipo = "OK";
        //    if (entrada == null)
        //    {
        //        salida.mensaje = "No existe el parámetro de entrada";
        //        salida.tipo = "ADVERTENCIA";
        //        return puedeContinuar;
        //    }
        //    if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(usuario))
        //    {
        //        salida.mensaje = "El campo usuario se encuentra vacío.";
        //        salida.tipo = "ADVERTENCIA";
        //        return puedeContinuar;
        //    }
        //    if (string.IsNullOrEmpty(controlador) || string.IsNullOrEmpty(controlador))
        //    {
        //        salida.mensaje = "El campo controlador se encuentra vacío.";
        //        salida.tipo = "ADVERTENCIA";
        //        return puedeContinuar;
        //    }
        //    if (string.IsNullOrEmpty(pcclient) || string.IsNullOrEmpty(pcclient))
        //    {
        //        salida.mensaje = "El campo pcclient se encuentra vacío.";
        //        salida.tipo = "ADVERTENCIA";
        //        return puedeContinuar;
        //    }
            
        //    puedeContinuar = true;
        //    return puedeContinuar;
        //}

        //public bool ValidarDatosEliminacionClienteBeneficiario(ref BeneficiarioDeleteViewModel model
        //     , string usuario, string controlador, string pcclient
        //    , ref ResultadoDTO<string> salida)
        //{
        //    bool puedeContinuar = false;
        //    var parametros = $"ValidadoresBeneficiariosRequest Service Layer Try: Modelo {model}";
        //    var props = new Dictionary<string, object>(){
        //                    { "Metodo", "ValidarDatosEliminacionClienteBeneficiario" },
        //                    { "Sitio", "COMODATO-API" },
        //                    { "Parametros", parametros }
        //            };

        //    if (model == null)
        //    {
        //        using (_logger.BeginScope(props))
        //        {
        //            _logger.LogError($"El objeto Respuesta desde el cliente para eliminar es Nulo. (1)");
        //        }
                
        //        salida.mensaje = "No hay datos correctos para eliminar. (1)";
        //        salida.tipo = "ADVERTENCIA";
        //        return puedeContinuar;
        //    }
        //    if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(usuario))
        //    {
        //        salida.mensaje = "El campo usuario se encuentra vacío.";
        //        salida.tipo = "ADVERTENCIA";
        //        return puedeContinuar;
        //    }
        //    if (string.IsNullOrEmpty(controlador) || string.IsNullOrEmpty(controlador))
        //    {
        //        salida.mensaje = "El campo controlador se encuentra vacío.";
        //        salida.tipo = "ADVERTENCIA";
        //        return puedeContinuar;
        //    }
        //    if (string.IsNullOrEmpty(pcclient) || string.IsNullOrEmpty(pcclient))
        //    {
        //        salida.mensaje = "El campo pcclient se encuentra vacío.";
        //        salida.tipo = "ADVERTENCIA";
        //        return puedeContinuar;
        //    }


        //    puedeContinuar = true;
        //    return puedeContinuar;
        //}
    }
}
