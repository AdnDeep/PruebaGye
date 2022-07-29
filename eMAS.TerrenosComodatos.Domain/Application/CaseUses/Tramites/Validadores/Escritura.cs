using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresTramite
    {
        public bool RespuestaServidorRemotoEscritura(ref ResultadoDTO<int> entrada
            , ref ResultadoDTO<int> salida)
        {
            bool puedeContinuar = false;
            salida.tipo = "EXITO";
            salida.mensaje = "OK";
            var parametros = $"ValidadoresBeneficiario Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "RespuestaServidorRemotoEscritura" },
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
        public bool DataClienteEscritura(ref TramiteEditViewModel entrada, ref ResultadoDTO<int> salida)
        {
            bool puedeContinuar = false;
            salida.tipo = "EXITO";
            salida.mensaje = "OK";
            if (entrada == null)
            {
                salida.mensaje = "No hay datos para guardar. (1)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.idbeneficiario <= 0)
            {
                salida.mensaje = "Seleccionar el beneficiario es obligatorio. (2)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            //if (entrada.idsector <= 0)
            //{
            //    salida.mensaje = "Indicar el Sector es obligatorio. (3)";
            //    salida.tipo = "ADVERTENCIA";
            //    return puedeContinuar;
            //}
            //if (entrada.manzana <= 0)
            //{
            //    salida.mensaje = "Indicar la manzana es obligatorio. (3)";
            //    salida.tipo = "ADVERTENCIA";
            //    return puedeContinuar;
            //}
            //if (entrada.lote <= 0)
            //{
            //    salida.mensaje = "Indicar el lote es obligatorio. (3)";
            //    salida.tipo = "ADVERTENCIA";
            //    return puedeContinuar;
            //}
            //if (entrada.division <= 0)
            //{
            //    salida.mensaje = "Indicar la división es obligatorio. (3)";
            //    salida.tipo = "ADVERTENCIA";
            //    return puedeContinuar;
            //}
           
            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
