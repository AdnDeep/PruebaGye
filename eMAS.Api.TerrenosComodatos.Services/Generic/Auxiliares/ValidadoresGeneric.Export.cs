using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ValidadoresGeneric
    {
        public bool ValidaRepuestaExportacionServidor(ref Tuple<List<ExportSingle>, string, string> entrada
            , ref ResultadoDTO<ExportSingleResult> salida)
        {
            List<Mensaje> lsMensajes = new List<Mensaje>();
            bool puedeContinuar = false;
            var parametros = $"ValidaRepuestaExportacionServidor Service Layer: Resultado Capa Logic ValidaRepuestaExportacionServidor";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ValidaRepuestaExportacionServidor" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };

            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El objeto devuelto de la base de datos es nulo (1).");
                }
                salida.mensaje = "Se ha producido un inconveniente en el aplicativo, por favor intente después de unos minutos [1].";
                salida.tipo = "ERROR";
                return puedeContinuar;
            }
            // Columna que podría contener algún error de Base de Datos
            string respuestaColumnas = entrada.Item2;
            List<ExportSingle> respuestaData = entrada.Item1;
            string mensajeInterno = "";
            if (string.IsNullOrEmpty(respuestaColumnas))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El objeto devuelto de la base de datos es nulo. No hay información de columnas(2).");
                }
                salida.mensaje = "Se ha producido un inconveniente en el aplicativo, por favor intente después de unos minutos [1].";
                salida.tipo = "ERROR";
                return puedeContinuar;
            }
            if (respuestaColumnas.Contains("NOHAYDATOS"))
            {
                mensajeInterno = respuestaColumnas.Split("||")[1];

                lsMensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSER",
                    descripcion = mensajeInterno,
                    tipo = "ADVERTENCIA"
                });
                salida.dataresult.codigoestado = 500;
                salida.mensajes = lsMensajes;
                salida.mensaje = "Se ha producido un inconveniente en el aplicativo, por favor intente después de unos minutos [2].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (respuestaColumnas.Contains("ERRORCAPTURADO"))
            {
                mensajeInterno = respuestaColumnas.Split("||")[1];
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"{mensajeInterno}");
                }
                salida.dataresult.codigoestado = 500;
                salida.mensajes = lsMensajes;
                salida.mensaje = "Se ha producido un inconveniente en el aplicativo, por favor intente después de unos minutos [3].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (respuestaData == null)
            {
                lsMensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSER",
                    descripcion = "No se han encontrado datos para la consulta solicitada.",
                    tipo = "ADVERTENCIA"
                });
                salida.dataresult.codigoestado = 204;
                salida.mensajes = lsMensajes;
                salida.mensaje = "Se ha producido un inconveniente en el aplicativo, por favor intente después de unos minutos [4].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (respuestaData.Count == 0)
            {
                lsMensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSER",
                    descripcion = "No se han encontrado datos para la consulta solicitada.",
                    tipo = "ADVERTENCIA"
                });
                salida.dataresult.codigoestado = 204;
                salida.mensajes = lsMensajes;
                salida.mensaje = "Se ha producido un inconveniente en el aplicativo, por favor intente después de unos minutos [4].";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
