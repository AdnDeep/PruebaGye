using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresTramite
    {
        public bool DataClienteEscrituraDetalle<T>(string entrada, ref ResultadoDTO<int> salida, ref T modelo)
        {
            bool puedeContinuar = false;
            salida.tipo = "EXITO";
            salida.mensaje = "OK";
            var parametros = $"ValidadoresTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "DataClienteEscrituraDetalle" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            if (string.IsNullOrEmpty(entrada) || string.IsNullOrWhiteSpace(entrada))
            {
                salida.mensaje = "No hay datos para guardar. (1)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            try
            {
                modelo = JsonConvert.DeserializeObject<T>(entrada);
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

            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool RespuestaServidorRemotoEscrituraDetail<T>(ref ResultadoDTO<int> entrada
            , ref ResultadoDTO<int> salida)
        {
            bool puedeContinuar = false;
            salida.tipo = "EXITO";
            salida.mensaje = "OK";
            var parametros = $"ValidadoresTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "RespuestaServidorRemotoEscrituraDetail" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta desde el servidor es un objeto nulo [1].");
                }
                salida.mensaje = "Se produjo un error en el aplicativo [1].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.tipo) || string.IsNullOrWhiteSpace(entrada.tipo))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El tipo de respuesta desde el servidor es de tipo incorrecto [2].");
                }
                salida.mensaje = "Se produjo un error en el aplicativo [2].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            // Buscamos Mensajes Internos De errores por validaciones
            var _mensajes = entrada.mensajes;
            if (_mensajes != null && _mensajes.Count > 0)
            {
                var _mensajeVLNVALCLI = _mensajes.FirstOrDefault(fod => fod.codigo == "VLNVALCLI");
                if (_mensajeVLNVALCLI != null)
                {
                    salida.mensaje = $"{_mensajeVLNVALCLI.descripcion}";
                    salida.tipo = "ADVERTENCIA";
                    return puedeContinuar;
                }
                var _mensajeVLNVALSERV = _mensajes.FirstOrDefault(fod => fod.codigo == "VLNVALSERV");
                if (_mensajeVLNVALSERV != null)
                {
                    salida.mensaje = $"{_mensajeVLNVALSERV.descripcion}";
                    salida.tipo = "ADVERTENCIA";
                    return puedeContinuar;
                }
            }
            if (entrada.tipo != "EXITO")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El resultado del objeto respuesta desde el servidor es un objeto nulo [3].");
                }
                salida.mensaje = "Se produjo un error en el aplicativo [3].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
