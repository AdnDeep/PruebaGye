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
    public partial class ValidadoresLecturaTramite
    {
        public bool ResultadoLogicConsultaOficioPorId(ref Tuple<SmcOficioOtrasDireccioneEdit, string, short> entradaAValidar
                            , ref ResultadoDTO<OficioTramiteEditViewModel> salida)
        {
            var parametros = $"ValidadoresLecturaTramite Service Layer";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ResultadoLogicConsultaOficioPorId" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            List<Mensaje> lsMensajes = new List<Mensaje>();
            bool puedeContinuar = false;
            salida.dataresult = new OficioTramiteEditViewModel();
            if (entradaAValidar == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"ResultadoLogicConsultaOficioPorId El objeto devuelto de la base de datos es nulo");
                }
                salida.mensaje = "Se produjo un error en la aplicación (1). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (entradaAValidar.Item1 == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"ResultadoLogicConsultaOficioPorId El objeto devuelto de la base de datos es nulo (1)");
                }
                salida.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entradaAValidar.Item2)
                || string.IsNullOrWhiteSpace(entradaAValidar.Item2))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"ResultadoLogicConsultaOficioPorId El objeto devuelto de la base de datos es nulo (2)");
                }
                salida.mensaje = "Se produjo un error en la aplicación (3). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entradaAValidar.Item3 > 1)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"ResultadoLogicConsultaOficioPorId MensajeBD {entradaAValidar.Item2}");
                }
                lsMensajes.Add(new Mensaje
                {
                    codigo = "RESPERRSERV",
                    descripcion = $"{entradaAValidar.Item2}",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;

                salida.mensaje = "Hay Errores en los datos de la aplicación.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entradaAValidar.Item3 == 0)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"ResultadoLogicConsultaOficioPorId MensajeBD {entradaAValidar.Item2}");
                }
                lsMensajes.Add(new Mensaje
                {
                    codigo = "RESPERRSERV",
                    descripcion = $"{entradaAValidar.Item2}",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;

                salida.mensaje = "El registro seleccionado no existe, por favor cree uno nuevo.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entradaAValidar.Item2 != "OK")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"ResultadoLogicConsultaOficioPorId Error {entradaAValidar.Item2}");
                }

                salida.mensaje = "Se produjo un error en la aplicación (3). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }

        public bool ResultadoLogicConsultaOficioPorIdTramite(ref Tuple<List<SmcOficioOtrasDireccioneEdit>, string> entrada
            , ref ResultadoDTO<List<OficioTramiteListViewModel>> salida)
        {
            var parametros = $"ValidadoresLecturaTramite Service Layer";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ResultadoLogicConsultaOficioPorIdTramite" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            List<Mensaje> lsMensajes = new List<Mensaje>();
            bool puedeContinuar = false;
            salida.dataresult = new List<OficioTramiteListViewModel>();

            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El objeto devuelto de la base de datos es nulo (1).");
                }

                salida.mensaje = "Se produjo un error en la aplicación (1). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.Item1 == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El objeto devuelto de la base de datos es nulo (2).");
                }

                salida.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;

        }
    }
}
