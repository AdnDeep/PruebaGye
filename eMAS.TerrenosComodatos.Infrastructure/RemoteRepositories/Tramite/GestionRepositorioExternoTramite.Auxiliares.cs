using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        private void ProcesaRespuestaServidorRemoto<T>(ref Tuple<int, string> entrada, string metodo, ref ResultadoDTO<T> respuestaRemota)
        {
            var parametros = $"GestionRepositorioExternoTramite Service Layer";
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
                respuestaRemota.dataresult = default(T);
                respuestaRemota.tipo = "ADVERTENCIA";
                respuestaRemota.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [1].";
                return;
            }
            if (entrada.Item1 == 204)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. Se produjo un error la respuesta está vacía desde el servidor.");
                }
                respuestaRemota.dataresult = default(T);
                respuestaRemota.tipo = "ADVERTENCIA";
                respuestaRemota.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [2].";
                return;
            }
            if (entrada.Item1 == 500)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. Se produjo una excepción {entrada.Item2}");
                }
                respuestaRemota.dataresult = default(T);
                respuestaRemota.tipo = "ADVERTENCIA";
                respuestaRemota.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [3].";
                return;
            }
            if (entrada.Item1 == 404)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. El recurso solicitado no existe.");
                }
                respuestaRemota.dataresult = default(T);
                respuestaRemota.tipo = "ADVERTENCIA";
                respuestaRemota.mensaje = "Se produjo un inconveniente. El recurso solicitado no existe. [4]";
                return;
            }
            if (entrada.Item1 == 401)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. El recurso solicitado no existe.");
                }
                respuestaRemota.dataresult = default(T);
                respuestaRemota.tipo = "ADVERTENCIA";
                respuestaRemota.mensaje = "Se produjo un inconveniente. No está facultado para consumir este recurso. [4]";
                return;
            }
            if (string.IsNullOrEmpty(entrada.Item2) || string.IsNullOrWhiteSpace(entrada.Item2))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. La respuesta desde el servidor está vacío");
                }
                respuestaRemota.dataresult = default(T);
                respuestaRemota.tipo = "ADVERTENCIA";
                respuestaRemota.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [4].";
                return;
            }
            string contenidoRespuestaServidor = entrada.Item2;
            try
            {
                respuestaRemota = JsonSerializer.Deserialize<ResultadoDTO<T>>(contenidoRespuestaServidor);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. Parametro {contenidoRespuestaServidor} Se produjoo un error deserializando la respuesta del servidor Excepcion {ex}");
                }
                respuestaRemota.dataresult = default(T);
                respuestaRemota.tipo = "ADVERTENCIA";
                respuestaRemota.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [5].";
                return;
            }
            if (entrada.Item1 == 400)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. BadRequest {respuestaRemota.mensaje}");
                }
                respuestaRemota.dataresult = default(T);
                respuestaRemota.tipo = "ADVERTENCIA";
                respuestaRemota.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [6].";
                return;
            }
        }

    }
}
