using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresTramite
    {
        public bool InputClienteGetDetailPorId<T>(short id
            , ref ResultadoDTO<T> salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "InputClienteGetDetailPorId" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            if (id <= 0)
            {
                salida.mensaje = "Input Request Incorrecta debe ser mayor que 0";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            
            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool InputClientGetDetailListPorIdTramite<T>(short idtramite
            , ref ResultadoDTO<T> salida)
        {
            bool puedeContinuar = false;
            var parametros = $"ValidadoresTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "InputClientGetDetailListPorIdTramite" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            
            if (idtramite <= 0)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Input Request Incorrecta debe ser mayor que 0");
                }
                salida.mensaje = "Se produjo un error en el aplicativo {1}.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
