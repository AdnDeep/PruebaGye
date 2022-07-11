
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresTramite
    {
        public bool RespuestaServidorRemotoById(ref ResultadoDTO<TramiteEditViewModel> entrada
            , ref ResultadoDTO<TramiteEditViewModel> salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "RespuestaServidorRemotoById" },
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
                    _logger.LogError($"El tipo de respuesta desde el servidor es de tipo incorrecto [3].");
                }
                salida.mensaje = "Se produjo un error en el aplicativo [3].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            // Buscamos Mensajes Internos De errores por validaciones
            var _mensajes = entrada.mensajes;
            if (_mensajes != null && _mensajes.Count > 0)
            {
                var _mensajeRESPERRSERV = _mensajes.FirstOrDefault(fod => fod.codigo == "RESPERRSERV");
                if (_mensajeRESPERRSERV != null)
                {
                    salida.mensaje = $"{_mensajeRESPERRSERV.descripcion}";
                    salida.tipo = "ADVERTENCIA";
                    return puedeContinuar;
                }
            }
            if (entrada.dataresult == null && entrada.tipo != "EXITO")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El resultado del objeto respuesta desde el servidor es un objeto nulo [4].");
                }
                salida.mensaje = "Se produjo un error en el aplicativo [4].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            
            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
