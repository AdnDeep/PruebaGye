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
        private void ProcesaRespuestaServidorRemoto<T>(ref Tuple<int, string> entrada, string metodo, ref T respuestaRemota)
        {
            var parametros = $"GestionRepositorioExternoSeguridad Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ProcesaRespuestaServidorRemoto" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}.La respuesta desde el servidor es NULO.");
                }
                return;
            }
            if (entrada.Item1 == 204)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. Se produjo un error la respuesta está vacía desde el servidor.");
                }
                return;
            }
            if (entrada.Item1 == 500)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. Se produjo una excepción {entrada.Item2}");
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
