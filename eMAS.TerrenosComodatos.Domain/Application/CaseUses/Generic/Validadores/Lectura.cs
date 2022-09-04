
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresGenerico
    {
        private readonly ILogger<ValidadoresGenerico> _logger;
        public ValidadoresGenerico(ILogger<ValidadoresGenerico> logger)
        {
            _logger = logger;
        }
        public bool InputClientGetDsrByKey(string keyParam, string target, ref StructKeyValueSelect salida) 
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresBeneficiario Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "InputClientGetDsr" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            if (string.IsNullOrEmpty(keyParam) || string.IsNullOrWhiteSpace(keyParam))
            {
                salida.target = "La clave de búsqueda para la consulta simple genérica es obligatoria.";
                salida.key = "ERROR";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(target) || string.IsNullOrWhiteSpace(target))
            {
                salida.target = "La clave de búsqueda para la consulta simple genérica es obligatoria.";
                salida.key = "ERROR";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool RespuestaServidorGetDsrByKey(ref ResultadoDTO<StructKeyValueSelect> entrada
            , ref StructKeyValueSelect salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresBeneficiario Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "InputClientGetPagedData" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };

            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta desde el servidor es un objeto nulo [1].");
                }
                salida.target = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [1].";
                salida.key = "ERROR";
                return puedeContinuar;
            }

            if (string.IsNullOrEmpty(entrada.tipo) || string.IsNullOrWhiteSpace(entrada.tipo))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El tipo de respuesta desde el servidor es de tipo incorrecto [3].");
                }
                salida.target = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [3].";
                salida.key = "ERROR";
                return puedeContinuar;
            }

            // Buscamos Mensajes Internos De errores por validaciones
            var _mensajes = entrada.mensajes;
            if (_mensajes != null && _mensajes.Count > 0)
            {
                var _mensajeRESPERRSERV = _mensajes.FirstOrDefault(fod => fod.codigo == "VLNVALSER");
                if (_mensajeRESPERRSERV != null)
                {
                    salida.target = $"{_mensajeRESPERRSERV.descripcion}";
                    salida.key = "ERROR";
                    return puedeContinuar;
                }
            }
            if (entrada.dataresult == null && entrada.tipo != "EXITO")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El resultado del objeto respuesta desde el servidor es un objeto nulo [4].");
                }
                salida.target = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [4].";
                salida.key = "ERROR";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
