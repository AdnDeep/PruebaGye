using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ValidadoresGeneric
    {
        private readonly ILogger<ValidadoresGeneric> _logger;
        public ValidadoresGeneric(ILogger<ValidadoresGeneric> logger)
        {
            _logger = logger;
        }
        public bool ValidaRespuestaServidor( ref Tuple<List<KeyValueSelect>, string> entrada
            , ref ResultadoDTO<StructKeyValueSelect> salida)
        {
            List<Mensaje> lsMensajes = new List<Mensaje>();
            bool puedeContinuar = false;
            var parametros = $"ValidadoresGeneric Service Layer: ResultadoLogicConsultaPaginado";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ValidaRespuestaServidor" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };

            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El objeto devuelto de la base de datos es nulo (1).");
                }
                salida.mensaje = "Se produjo un error en el aplicativo (1).";
                salida.tipo = "ERROR";
                return puedeContinuar;
            }

            if (entrada.Item1 == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El objeto devuelto de la base de datos es nulo (2).");
                }
                salida.mensaje = "Se produjo un error en el aplicativo (2).";
                salida.tipo = "ERROR";
                return puedeContinuar;
            }

            string mensajeDB = entrada.Item2;

            if (mensajeDB == "NOHAYDATOS")
            {
                lsMensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSER",
                    descripcion = "La clave consultada no se encontró en el sistema.",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;
                salida.mensaje = "La clave consultada no se encontró en el sistema.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (mensajeDB != "OK")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Ocurrió un error en la base de datos {mensajeDB}");
                }
                salida.mensaje = "Se produjo un error en el aplicativo (3).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
