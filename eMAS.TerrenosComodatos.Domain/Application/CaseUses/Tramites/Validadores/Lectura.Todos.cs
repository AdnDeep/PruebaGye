﻿
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
        public bool RespuestaServidorRemotoDataPaginada(ref ResultadoDTO<DataPagineada<TramiteListViewModel>> entrada
            , ref ResultadoDTO<DataPagineada<TramiteListViewModel>> salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "RespuestaServidorRemotoDataPaginada" },
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
            
            if (string.IsNullOrEmpty(entrada.tipo) || string.IsNullOrWhiteSpace(entrada.tipo))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El tipo de respuesta desde el servidor es de tipo incorrecto.");
                }
                salida.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [3].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (entrada.dataresult == null && entrada.tipo != "EXITO")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El resultado del objeto respuesta desde el servidor es un objeto nulo [4].");
                }
                salida.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [4].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
