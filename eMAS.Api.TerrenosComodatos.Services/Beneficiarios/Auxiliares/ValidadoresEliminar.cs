using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public class ValidadoresEliminar
    {
        private readonly ILogger<ValidadoresEscrituraBeneficiarios> _logger;
        public ValidadoresEliminar(ILogger<ValidadoresEscrituraBeneficiarios> logger)
        {
            _logger = logger;
        }
        public bool ValidaRespuestaServidorLogic(string entrada, ref ResultadoDTO<string> salida  )
        {
            bool puedeContinuar = false;
            List<Mensaje> lsMensajes = new List<Mensaje>();
            var parametros = $"ValidadoresEscrituraBeneficiarios Service Layer Try: Modelo {entrada}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ValidaRespuestaServidorLogic" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            if (string.IsNullOrEmpty(entrada) || string.IsNullOrWhiteSpace(entrada))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Los datos enviados desde el servidor de datos son incorrectos");
                }
                salida.mensaje = "Se produjo un error Interno en la aplicación. (1)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada != "OK")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Los datos enviados desde el servidor de datos son incorrectos");
                }
                lsMensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSERV",
                    descripcion = $"{entrada}",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;
                salida.mensaje = "Hay errores de datos en la aplicación [1].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool ValidarDatosEliminacionClienteBeneficiario(ref BeneficiarioDeleteViewModel model, ref ResultadoDTO<string> salida)
        {
            var parametros = $"ValidadoresEliminar Service Layer Try: Modelo {model}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ValidarDatosEliminacionClienteBeneficiario" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            bool puedeContinuar = false;
            List<Mensaje> lsMensajes = new List<Mensaje>();
            if (model.id == 0)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El objeto Respuesta desde el cliente para eliminar es 0 (1)");
                }
                lsMensajes.Add(new Mensaje
                {
                    codigo = "VLNVALCLI",
                    descripcion = "No hay datos correctos para eliminar.",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;
                salida.mensaje = "No hay datos correctos para eliminar. (2)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
