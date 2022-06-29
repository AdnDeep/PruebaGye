using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ValidadoresEscrituraBeneficiarios
    {
        public bool ValidarDatosServidorBeneficiarioEditModel(ref Tuple<List<SmcValidacionEscritura>, string> entrada
                    , ref ResultadoDTO<BeneficiarioEditViewModel> salida)
        {
            var parametros = $"ValidadoresEscrituraBeneficiarios Service Layer Try: Modelo {entrada}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ValidarDatosServidorBeneficiarioEditModel" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            bool puedeContinuar = false;
            salida.tipo = "EXITO";
            salida.mensaje = "OK";
            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"No se recuperaron datos del servidor para consultar los datos de valdación de Lógica de Negocios.");
                }
                salida.mensaje = "Se produjo un error Interno en la aplicación. (1)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.Item2) || string.IsNullOrWhiteSpace(entrada.Item2))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"No se recuperó mensaje correcto al consultar los datos de validación de Lógica de Negocios.");
                }
                salida.mensaje = "Se produjo un error Interno en la aplicación. (3)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.Item2 != "OK")
            {
                string mensaje = entrada.Item2;
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error BD al consultar los datos de validación de Lógica de Negocios. {mensaje}");
                }
                salida.mensaje = "Se produjo un error Interno en la aplicación. (4)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            // Logica de Negocios
            var dataTmp = entrada.Item1;

            if (dataTmp == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El objeto de Entidad Validacion de Logica de Negocios devuelto desde la BD se encuentra nulo");
                }
                salida.mensaje = "Se produjo un error Interno en la aplicación. (6)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            var dataNombreTmp = dataTmp.FirstOrDefault(fod => fod.clave == "NOMBRE");
            if (dataNombreTmp == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La clave Nombre no se encuentra en la BD.");
                }
                salida.mensaje = "Se produjo un error Interno en la aplicación. (7)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (dataNombreTmp.valorNumerico >= 1)
            {
                List<Mensaje> mensajes = new List<Mensaje>();
                mensajes.Add(new Mensaje 
                { 
                    codigo = "VLNVALSERV", 
                    descripcion ="El nombre a grabar ya existe en el sistema",
                    tipo ="ADVERTENCIA"
                });
                salida.mensajes = mensajes;
                salida.mensaje = "El nombre a grabar ya existe en el sistema.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }

        public bool ValidarRespuestaServidorGestionGrabar(ref Tuple<SmcBeneficiarioEdit, string> entrada, ref ResultadoDTO<BeneficiarioEditViewModel> salida)
        {
            var parametros = $"ValidadoresEscrituraBeneficiarios Service Layer Try: Modelo {entrada}";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ValidarRespuestaServidorGestionGrabar" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            bool puedeContinuar = false;
            salida.tipo = "EXITO";
            salida.mensaje = "OK";
            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El objeto Respuesta del servidor para la accion crear es nulo. (1)");
                }
                salida.mensaje = "Se produjo un error en el proceso de grabar en la aplicacion. (1)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            string mensaje = entrada.Item2;
            if (mensaje != "OK")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error BD al crear (2) . {mensaje}");
                }
                List<Mensaje> mensajes = new List<Mensaje>();
                mensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSERV",
                    descripcion = $"{mensaje}",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = mensajes;
                salida.mensaje = "Hay errores internos con los datos de la aplicacion. (2)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
