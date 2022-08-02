using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoSeguridad : IGestionRepositorioExternoSeguridad
    {
        private void ProcesaRespuestaServidorRemoto<T>(ref Tuple<int, string> entrada
            , string metodo
            , ref T respuestaRemota
            , ref string mensaje)
        {
            var parametros = $"GestionRepositorioExternoSeguridad Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ProcesaRespuestaServidorRemoto" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            mensaje = "OK";
            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}.La respuesta desde el servidor es NULO.");

                    mensaje = "La respuesta del Servidor Remoto es incorrecta [1].";
                }
                return;
            }
            if (entrada.Item1 == 204)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. Se produjo un error la respuesta está vacía desde el servidor.");
                    mensaje = "La respuesta del Servidor Remoto es incorrecta [2].";
                }
                return;
            }
            if (entrada.Item1 == 500)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. Se produjo una excepción {entrada.Item2}");
                    mensaje = "Se ha producido un error en el Servidor Remoto.";
                }
                return;
            }
            if (entrada.Item1 == 401)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. No está autorizado para consumir este recurso.");
                    mensaje = "El aplicativo no está facultado para consumir este recurso.";
                }
                return;
            }
            if (entrada.Item1 == 404)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. El recurso consumido no está encontrado.");
                    mensaje = "El recurso solicitado no se encuentra.";
                }
                return;
            }
            if (string.IsNullOrEmpty(entrada.Item2) || string.IsNullOrWhiteSpace(entrada.Item2))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. La respuesta desde el servidor está vacío");
                }
                return;
            }
            string contenidoRespuestaServidor = entrada.Item2;
            try
            {
                respuestaRemota = JsonSerializer.Deserialize<T>(contenidoRespuestaServidor);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. Parametro {contenidoRespuestaServidor} Se produjoo un error deserializando la respuesta del servidor Excepcion {ex}");
                    mensaje = "La respuesta del Servidor Remoto es incorrecta [3]";
                }
                return;
            }
            if (entrada.Item1 == 400)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. BadRequest");
                }
                return;
            }
        }

    }
}
