using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ValidadoresEliminacionTramite
    {
        private readonly ILogger<ValidadoresEliminacionTramite> _logger;
        public ValidadoresEliminacionTramite(ILogger<ValidadoresEliminacionTramite> logger)
        {
            _logger = logger;
        }
        public bool ValidarRespuestaServidorEntidadPrincipalAccionAEliminar(ref Tuple<short, string> entrada
            , ref ResultadoDTO<int> salida) 
        {
            var parametros = $"ValidadoresEliminacionTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ValidarRespuestaServidorEntidadPrincipalAccionAEliminar" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };
            bool puedeContinuar = false;
            List<Mensaje> lsMensajes = new List<Mensaje>();
            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de  Eliminacion Servidor de datos desde el servidor es nula (1).");
                }
                salida.mensaje = "Se produjo en error en el aplicativo (1).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.Item2) || string.IsNullOrWhiteSpace(entrada.Item2))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de  Eliminacion Servidor de datos desde el servidor es vacía (2).");
                }
                salida.mensaje = "Se produjo en error en el aplicativo (1).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.Item1 == 0 || entrada.Item1 > 1)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de  Eliminacion Servidor de datos es incorrecta {entrada.Item2}");
                }
                lsMensajes.Add(new Mensaje
                {
                    codigo = "RESPERRSERV",
                    descripcion = $"{entrada.Item2}",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;
                salida.mensaje = "Hay error en los datos del aplicativo.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.Item2 != "OK")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de  Eliminacion Servidor de datos es incorrecta {entrada.Item2}");
                }
                salida.mensaje = "Se produjo en error en el aplicativo (1).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}