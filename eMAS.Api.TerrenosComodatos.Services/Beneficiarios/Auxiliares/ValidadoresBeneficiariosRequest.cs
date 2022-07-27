using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public class ValidadoresBeneficiariosRequest
    {
        private readonly ILogger<ValidadoresBeneficiariosRequest> _logger;
        public ValidadoresBeneficiariosRequest(ILogger<ValidadoresBeneficiariosRequest> logger)
        {
            _logger = logger;
        }
        public bool ValidaDataRequestLecturaTodosPaginado(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila, ref ResultadoDTO<DataPagineada<BeneficiariosListViewModel>> salida)
        {
            bool puedeContinuar = false;
            salida.dataresult = new DataPagineada<BeneficiariosListViewModel>();
            if (string.IsNullOrEmpty(panelFilter) || string.IsNullOrWhiteSpace(panelFilter))
            {
                salida.mensaje = "Input Request Incorrecta, el objeto está vacío panelFilter";
                salida.tipo = "ERROR";
                return puedeContinuar;
            }

            try
            {
                var panelModel = JsonConvert.DeserializeObject<BeneficiariosPanelFilterModel>(panelFilter);
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

        public bool ValidarDatosClienteBeneficiarioEditViewModel(ref BeneficiarioEditViewModel entrada
            , string usuario, string controlador, string pcclient
            , ref ResultadoDTO<BeneficiarioEditViewModel> salida)
        {
            bool puedeContinuar = false;
            salida.mensaje = "OK";
            salida.tipo = "EXITO";
            if (entrada == null)
            {
                salida.mensaje = "No existe el parámetro de entrada";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(usuario))
            {
                salida.mensaje = "El campo usuario se encuentra vacío.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(controlador) || string.IsNullOrEmpty(controlador))
            {
                salida.mensaje = "El campo controlador se encuentra vacío.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(pcclient) || string.IsNullOrEmpty(pcclient))
            {
                salida.mensaje = "El campo pcclient se encuentra vacío.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            
            puedeContinuar = true;
            return puedeContinuar;
        }

        public bool ValidarDatosEliminacionClienteBeneficiario(short id
             , string usuario, string controlador, string pcclient
            , ref ResultadoDTO<string> salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresBeneficiariosRequest Service Layer Try: Modelo {id}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ValidarDatosEliminacionClienteBeneficiario" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };

            if (id <= 0)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El Id para eliminar es incorrecto");
                }
                
                salida.mensaje = "No hay datos correctos para eliminar. (1)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(usuario))
            {
                salida.mensaje = "El campo usuario se encuentra vacío.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(controlador) || string.IsNullOrEmpty(controlador))
            {
                salida.mensaje = "El campo controlador se encuentra vacío.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(pcclient) || string.IsNullOrEmpty(pcclient))
            {
                salida.mensaje = "El campo pcclient se encuentra vacío.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }


            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
