

using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic.Generic;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ServiceDataProviderGeneric : IServiceDataProviderGeneric
    {
        private readonly ValidadoresGeneric _validadoresGeneric;
        private readonly MapeadoresGeneric _mapeadoresGeneric;
        private readonly DataProviderLogicGeneric _logicDataProviderGeneric;
        private readonly ILogger<ServiceDataProviderGeneric> _logger;
        public ServiceDataProviderGeneric(ILogger<ServiceDataProviderGeneric> logger
            , DataProviderLogicGeneric logicDataProviderGeneric
            , ValidadoresGeneric validadoresGeneric
            , MapeadoresGeneric mapeadoresGeneric)
        {
            _validadoresGeneric = validadoresGeneric;
            _logger = logger;
            _mapeadoresGeneric = mapeadoresGeneric;
            _logicDataProviderGeneric = logicDataProviderGeneric;
        }
        public ResultadoDTO<StructKeyValueSelect> GetDataSrc(string key1, string keyEntity, string target)
        {
            ResultadoDTO<StructKeyValueSelect> resultadoVista = new ResultadoDTO<StructKeyValueSelect>();
            Tuple<List<KeyValueSelect>, string> respuestaLogic = null;
            var parametros = $"ServiceDataProviderGeneric Service Layer Try: Modelo {key1}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "Actualizar" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            try
            {
                respuestaLogic = _logicDataProviderGeneric.ObtenerDataByParam(key1, keyEntity);
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

            bool validaRespServ = _validadoresGeneric.ValidaRespuestaServidor(ref respuestaLogic, ref resultadoVista);

            if (!validaRespServ)
                return resultadoVista;

            _mapeadoresGeneric.MapearKeyValueSelectAStructKeyValueSelect(ref respuestaLogic
                , ref resultadoVista, key1, target);

            return resultadoVista;
        }
    }
}
