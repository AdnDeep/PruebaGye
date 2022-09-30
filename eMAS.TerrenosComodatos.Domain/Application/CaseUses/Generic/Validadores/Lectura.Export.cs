
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
        public bool InputServerGetExport(ref ResultadoDTO<ExportSingleResult> entrada, ref ResultadoDTO<ExportSingleResult> salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresGenerico Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "InputServerGetExport" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };

            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta desde el servidor es un objeto nulo [1].");
                }
                salida.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos {1}.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.tipo == "ADVERTENCIA")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta desde el servidor es un objeto nulo [1].");
                }
                salida.mensaje = entrada.mensaje;
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool InputClientGetExport(ExportSingleRequest entrada, ref ResultadoDTO<ExportSingleResult> salida) 
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresGenerico Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "InputClientGetExport" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };

            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta desde el servidor es un objeto nulo [1].");
                }
                salida.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [1].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.Codigo) || string.IsNullOrWhiteSpace(entrada.Codigo))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El campo código está vacío.");
                }
                salida.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [2].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.ParamsFilter) || string.IsNullOrWhiteSpace(entrada.ParamsFilter))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El campo ParamsFilter está vacío.");
                }
                salida.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [3].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            
            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
