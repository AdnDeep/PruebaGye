﻿using eMAS.Api.TerrenosComodatos.Entities;
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
        private readonly ILogger<ValidadoresLecturaTramite> _logger;
        public ValidadoresLecturaTramite(ILogger<ValidadoresLecturaTramite> logger)
        {
            _logger = logger;
        }
        public bool ResultadoLogicConsultaPorId(ref Tuple<SmcTramiteEdit, string, short> entradaAValidar
                            , ref ResultadoDTO<TramiteEditViewModel> salida)
        {
            var parametros = $"ValidadoresLecturaTramite Service Layer";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ResultadoLogicConsultaPorId" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };
            List<Mensaje> lsMensajes = new List<Mensaje>();
            bool puedeContinuar = false;
            if (entradaAValidar == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"ConsultarPorId El objeto devuelto de la base de datos es nulo");
                }

                salida.dataresult = new TramiteEditViewModel();
                salida.mensaje = "Se produjo un error en la aplicación (1). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (entradaAValidar.Item1 == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"ConsultarPorId El objeto devuelto de la base de datos es nulo (1)");
                }

                salida.dataresult = new TramiteEditViewModel();
                salida.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entradaAValidar.Item2)
                || string.IsNullOrWhiteSpace(entradaAValidar.Item2))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"ConsultarPorId El objeto devuelto de la base de datos es nulo (2)");
                }

                salida.dataresult = new TramiteEditViewModel();
                salida.mensaje = "Se produjo un error en la aplicación (3). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entradaAValidar.Item3 > 1)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"ConsultarPorId MensajeBD {entradaAValidar.Item2}");
                }
                lsMensajes.Add(new Mensaje
                {
                    codigo = "RESPREPTC",
                    descripcion = $"{entradaAValidar.Item2}",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;

                salida.dataresult = new TramiteEditViewModel();
                salida.mensaje = "Hay Errores en los datos de la aplicación.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entradaAValidar.Item3 == 0)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"ConsultarPorId MensajeBD {entradaAValidar.Item2}");
                }
                lsMensajes.Add(new Mensaje
                {
                    codigo = "RESPREPTC",
                    descripcion = $"{entradaAValidar.Item2}",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;

                salida.dataresult = new TramiteEditViewModel();
                salida.mensaje = "El registro seleccionado no existe, por favor cree uno nuevo.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool ResultadoLogicConsultaPaginado(ref Tuple<List<SmcTramitePaginado>, int> entrada
            , ref ResultadoDTO<DataPagineada<TramitesListViewModel>> salida)
        {
            bool puedeContinuar = false;

            var parametros = $"ValidadoresLecturaTramite Service Layer: ResultadoLogicConsultaPaginado";
            var props = new Dictionary<string, object>(){
                            { "Metodo", "ResultadoLogicConsultaPaginado" },
                            { "Sitio", "COMODATO-API" },
                            { "Parametros", parametros }
                    };

            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"El objeto devuelto de la base de datos es nulo.");
                }

                salida.dataresult = new DataPagineada<TramitesListViewModel>();
                salida.mensaje = "Se produjo un error en la aplicación (2). Vuelva a intentar.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
