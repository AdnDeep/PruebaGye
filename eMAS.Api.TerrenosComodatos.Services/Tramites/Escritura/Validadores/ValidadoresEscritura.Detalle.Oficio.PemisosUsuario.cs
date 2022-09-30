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
        public bool ValidarRespuestaServidorPermisosUsuario(ref RespuestaViewModel<List<UsuarioPerfilOpcion>> entrada
            , ref ResultadoDTO<int> salida
            , string[] perfilesPermitido
            , string accion)
        {
            var parametros = $"ValidarRespuestaServidorPermisosUsuario Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ValidarRespuestaServidorPermisosUsuario" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };
            bool puedeContinuar = false;
            List<Mensaje> lsMensajes = new List<Mensaje>();
            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de Obtención de permisos desde el Servidor de datos desde el servidor es nula (1).");
                }
                salida.mensaje = "Se produjo un inconveniente en el aplicativo (1).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (!entrada.Resultado.Ok)
            {
                if (entrada.Resultado.Mensajes != null)
                {
                    string strLOGINTERNOCompleto = entrada.Resultado.Mensajes.FirstOrDefault(fod => fod.Contains("LOGINTERNO"));
                    string strMENSAJEUSUARIOCompleto = entrada.Resultado.Mensajes.FirstOrDefault(fod => fod.Contains("MENSAJEUSUARIO"));
                    if (!(string.IsNullOrEmpty(strLOGINTERNOCompleto) || string.IsNullOrWhiteSpace(strLOGINTERNOCompleto)))
                    {
                        using (_logger.BeginScope(props))
                        {
                            string strLogInterno = strLOGINTERNOCompleto.Split("||")[1];
                            _logger.LogError($"{strLogInterno}");
                        }
                    }
                    if (!(string.IsNullOrEmpty(strMENSAJEUSUARIOCompleto) || string.IsNullOrWhiteSpace(strMENSAJEUSUARIOCompleto)))
                    {
                        string strMENSAJEUSUARIO = strMENSAJEUSUARIOCompleto.Split("||")[1];
                         
                        salida.mensaje = $"{strMENSAJEUSUARIO}";
                        salida.tipo = "ADVERTENCIA";
                        return puedeContinuar;
                    }
                }
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de Obtención de permisos desde el Servidor de datos fue incorrecta (2).");
                    _logger.LogError($"{entrada.Resultado.Titulo}");
                }
                salida.mensaje = "Se produjo un inconveniente en el aplicativo (2).";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.DataResult == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de Obtención de permisos desde el Servidor de datos fue incorrecta (3).");
                }
                salida.mensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSERV",
                    descripcion = $"No se encontraron perfiles para el usuario.",
                    tipo = "ADVERTENCIA"
                });

                salida.mensaje = "No se encontraron perfiles para el usuario.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            var lsPerfilesEncontrados = entrada.DataResult.Where(w => perfilesPermitido.Contains(w.NombrePerfil.Trim().ToUpper())).ToList();

            if (lsPerfilesEncontrados.Count == 0)
            {
                salida.mensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSERV",
                    descripcion = $"El usuario no tiene el perfil para utilizar esta acción {accion}.",
                    tipo = "ADVERTENCIA"
                });

                salida.mensaje = $"El usuario no tiene el perfil para utilizar esta acción {accion}.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            
            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}