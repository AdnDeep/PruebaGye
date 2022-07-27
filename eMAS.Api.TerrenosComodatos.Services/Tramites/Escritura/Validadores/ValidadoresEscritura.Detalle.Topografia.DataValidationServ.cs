using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ValidadoresEscrituraTramite
    {
        public bool ValidaRespuestLogicDataValidationEscrituraTramiteTopografiaServidor(int idtopografiatramite, int idTramite, ref Tuple<List<SmcValidaDataServidor>,string> entrada
            , ref ResultadoDTO<int> salida)
        {
            var parametros = $"ValidadoresEscrituraTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ValidaRespuestLogicDataValidationEscrituraTramiteTopografiaServidor" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };
            bool puedeContinuar = false;
            List<Mensaje> lsMensajes = new List<Mensaje>();
            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de validacion de datos desde el servidor es nula (1).");
                }
                salida.mensaje = "Se produjo en error en el aplicativo";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.Item1 == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La respuesta de validacion de datos desde el servidor es nula (2).");
                }
                salida.mensaje = "Se produjo en error en el aplicativo";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.Item2) || string.IsNullOrWhiteSpace(entrada.Item2))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Se produjo un error en el servidor de datos (3).");
                }
                salida.mensaje = "Se produjo en error en el aplicativo.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.Item2 != "OK")
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error BD ConsultaDataValidation {entrada.Item2}");
                }
                salida.mensaje = "Se produjo en error en el aplicativo.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            var lsValidacion = entrada.Item1;

            var existeTramiteTmp = lsValidacion.FirstOrDefault(fod => fod.CLAVE == "EXISTETRAMITE");
            if (existeTramiteTmp == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La clave EXISTETRAMITE no se encuentra en la BD.");
                }
                salida.mensaje = "Se produjo un error Interno en la aplicación. (7)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (!existeTramiteTmp.VALORBOOLEANO)
            {
                lsMensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSERV",
                    descripcion = "El trámite indicado no existe en el sistema o está dado de baja.",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;
                salida.mensaje = "El trámite indicado no existe en el sistema o está dado de baja.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (idtopografiatramite > 0) 
            {
                var existeTopografiaTramiteTmp = lsValidacion.FirstOrDefault(fod => fod.CLAVE == "EXISTETOPOGRAFIATRAMITE");
                if (existeTopografiaTramiteTmp == null)
                {
                    using (_logger.BeginScope(props))
                    {
                        _logger.LogError($"La clave EXISTETOPOGRAFIATRAMITE no se encuentra en la BD.");
                    }
                    salida.mensaje = "Se produjo un error Interno en la aplicación. (7)";
                    salida.tipo = "ADVERTENCIA";
                    return puedeContinuar;
                }
                if (!existeTopografiaTramiteTmp.VALORBOOLEANO)
                {
                    lsMensajes.Add(new Mensaje
                    {
                        codigo = "VLNVALSERV",
                        descripcion = "La Topografía trámite indicado no existe en el sistema o está dado de baja.",
                        tipo = "ADVERTENCIA"
                    });
                    salida.mensajes = lsMensajes;
                    salida.mensaje = "La Topografía trámite indicado no existe en el sistema o está dado de baja.";
                    salida.tipo = "ADVERTENCIA";
                    return puedeContinuar;
                }
                if (idTramite > 0)
                {
                    var existeRelacionTopografiaTramiteTmp = lsValidacion.FirstOrDefault(fod => fod.CLAVE == "EXISTERELACION");
                    if (existeRelacionTopografiaTramiteTmp == null)
                    {
                        using (_logger.BeginScope(props))
                        {
                            _logger.LogError($"La clave EXISTERELACION no se encuentra en la BD.");
                        }
                        salida.mensaje = "Se produjo un error Interno en la aplicación. (7)";
                        salida.tipo = "ADVERTENCIA";
                        return puedeContinuar;
                    }
                    if (!existeRelacionTopografiaTramiteTmp.VALORBOOLEANO)
                    {
                        lsMensajes.Add(new Mensaje
                        {
                            codigo = "VLNVALSERV",
                            descripcion = "La Topografía no tiene relación con el trámite indicado no existe en el sistema o está dado de baja.",
                            tipo = "ADVERTENCIA"
                        });
                        salida.mensajes = lsMensajes;
                        salida.mensaje = "La Topografía no tiene relación con el trámite indicado no existe en el sistema o está dado de baja.";
                        salida.tipo = "ADVERTENCIA";
                        return puedeContinuar;
                    }
                }
            }

            var existeTipoTopografiaTmp = lsValidacion.FirstOrDefault(fod => fod.CLAVE == "EXISTETIPOTOPOGRAFIA");
            if (existeTipoTopografiaTmp == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La clave EXISTETIPOTOPOGRAFIA no se encuentra en la BD.");
                }
                salida.mensaje = "Se produjo un error Interno en la aplicación. (7)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (!existeTipoTopografiaTmp.VALORBOOLEANO)
            {
                lsMensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSERV",
                    descripcion = "El Tipo Topográfico indicado no existe en el sistema o está dado de baja.",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;
                salida.mensaje = "El Tipo Topográfico indicado no existe en el sistema o está dado de baja.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }


            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}