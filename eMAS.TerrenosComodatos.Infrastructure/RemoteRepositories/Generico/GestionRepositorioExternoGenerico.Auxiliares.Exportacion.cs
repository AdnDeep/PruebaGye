using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoGenerico : IGestionRepositorioExternoGenerico
    {
        private void ProcesaRespuestaServidorRemotoExportacion<T>(ref Tuple<int, string> entrada, string metodo, ref ResultadoDTO<T> respuestaRemota)
        {
            var parametros = $"GestionRepositorioExternoGenerico Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ProcesaRespuestaServidorRemotoExportacion" },
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
            if (entrada.Item1 == 404)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. El recurso solicitado no existe.");
                }
                respuestaRemota.dataresult = default(T);
                respuestaRemota.tipo = "ADVERTENCIA";
                respuestaRemota.mensaje = "Se produjo un inconveniente en el aplicativo. El recurso solicitado no existe. [2]";
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
                respuestaRemota.mensaje = "Se produjo un inconveniente en el aplicativo. No está facultado para consumir este recurso. [3]";
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
                respuestaRemota.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [4].";
                return;
            }
            Mensaje _mensajeVLNVALSERV = null;
            if (entrada.Item1 == 204)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. Se produjo un error la respuesta está vacía desde el servidor.");
                }
                _mensajeVLNVALSERV = respuestaRemota.mensajes?.FirstOrDefault(fod => fod.codigo == "VLNVALSERV");
                if (_mensajeVLNVALSERV != null)
                {
                    respuestaRemota.tipo = "ADVERTENCIA";
                    respuestaRemota.mensaje = $"{_mensajeVLNVALSERV.descripcion}";
                    return;
                }
                respuestaRemota.tipo = "ADVERTENCIA";
                respuestaRemota.mensaje = "No se ha encontrado Datos para la exportación solicitada.";
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
                    _logger.LogError($"Error procesando el método: {metodo}. Parametro Se produjoo un error deserializando la respuesta del servidor Excepcion {ex}");
                }
                respuestaRemota.dataresult = default(T);
                respuestaRemota.tipo = "ADVERTENCIA";
                respuestaRemota.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [6].";
                return;
            }
            
            
            if (entrada.Item1 == 500)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. Se produjo una excepción {entrada.Item2}");
                }
                _mensajeVLNVALSERV = respuestaRemota.mensajes?.FirstOrDefault(fod => fod.codigo == "VLNVALSERV");
                if (_mensajeVLNVALSERV != null)
                {
                    respuestaRemota.tipo = "ADVERTENCIA";
                    respuestaRemota.mensaje = $"{_mensajeVLNVALSERV.descripcion}";
                    return;
                }
                respuestaRemota.tipo = "ADVERTENCIA";
                respuestaRemota.mensaje = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [7].";

                return;
            }
        }
    }
}
