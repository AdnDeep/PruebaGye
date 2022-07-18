using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ValidadoresEscrituraTramite
    {
        private readonly ILogger<ValidadoresEscrituraTramite> _logger;
        public ValidadoresEscrituraTramite(ILogger<ValidadoresEscrituraTramite> logger)
        {
            _logger = logger;
        }
        public bool ValidarDatosClienteTramiteEditViewModel(ref TramiteEditViewModel entrada
            , ref ResultadoDTO<int> salida)
        {
            var parametros = $"ValidadoresEscrituraTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ValidarDatosClienteTramiteEditViewModel" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };
            bool puedeContinuar = false;
            salida.mensaje = "OK";
            salida.tipo = "EXITO";
            List<Mensaje> lsMensajes = new List<Mensaje>();

            if (entrada.idbeneficiario <= 0)
            {
                lsMensajes.Add(new Mensaje
                {
                    codigo = "VLNVALCLI",
                    descripcion = "Escoger el beneficiario es obligatorio.",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;
                salida.mensaje = "Escoger el beneficiario es obligatorio.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            
            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool ValidarRespuestaServidorEntidadPrincipalAccionAgregar(ref Tuple<short, string> entrada
            , ref ResultadoDTO<int> salida) 
        {
            var parametros = $"ValidadoresEscrituraTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ValidarRespuestaServidorEntidadPrincipal" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };
            bool puedeContinuar = false;

            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de  Escritura Servidor de datos desde el servidor es nula (1).");
                }
                salida.mensaje = "Se produjo en error en el aplicativo";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.Item2) || string.IsNullOrWhiteSpace(entrada.Item2))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de  Escritura Servidor de datos desde el servidor es vacía (2).");
                }
                salida.mensaje = "Se produjo en error en el aplicativo (1_).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.Item2 != "OK")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de  Escritura Servidor de datos es incorrecta {entrada.Item2}");
                }
                salida.mensaje = "Se produjo en error en el aplicativo (1=).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.Item1 <= 0)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de  Escritura Servidor de datos generó un Id de Inserción incorrecto");
                }
                salida.mensaje = "Se produjo en error en el aplicativo (2).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool ValidarRespuestaServidorEntidadPrincipalAccionActualizar(ref Tuple<short, string> entrada
            , ref ResultadoDTO<int> salida)
        {
            var parametros = $"ValidadoresEscrituraTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ValidarRespuestaServidorEntidadPrincipalAccionActualizar" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };
            bool puedeContinuar = false;
            List<Mensaje> lsMensajes = new List<Mensaje>();
            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de  Escritura Servidor de datos desde el servidor es nula (1).");
                }
                salida.mensaje = "Se produjo en error en el aplicativo (1).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.Item2) || string.IsNullOrWhiteSpace(entrada.Item2))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de  Escritura Servidor de datos desde el servidor es vacía (2).");
                }
                salida.mensaje = "Se produjo en error en el aplicativo (1).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.Item1 == 0 || entrada.Item1 > 1)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de  Escritura Servidor de datos es incorrecta {entrada.Item2}");
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
                    _logger.LogError($"La respuesta de  Escritura Servidor de datos es incorrecta {entrada.Item2}");
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