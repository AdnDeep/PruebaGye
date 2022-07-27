using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public class ValidadoresGenericRequest
    {
        private readonly ILogger<ValidadoresGenericRequest> _logger;
        public ValidadoresGenericRequest(ILogger<ValidadoresGenericRequest> logger)
        {
            _logger = logger;
        }
        public bool ValidaConsultaDataDsr(string key1, string target
            , ref ResultadoDTO<StructKeyValueSelect> salida)
        {
            bool puedeContinuar = false;

            if (string.IsNullOrEmpty(key1) || string.IsNullOrWhiteSpace(key1))
            {
                salida.mensaje = "Input Request Incorrecta, el objeto está vacío [1].";
                salida.tipo = "ERROR";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(target) || string.IsNullOrWhiteSpace(target))
            {
                salida.mensaje = "Input Request Incorrecta, el objeto está vacío [2].";
                salida.tipo = "ERROR";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
