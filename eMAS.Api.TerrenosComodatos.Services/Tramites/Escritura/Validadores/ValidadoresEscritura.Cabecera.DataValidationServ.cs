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
        public bool ValidaRespuestLogicDataValidationEscrituraTramiteServidor(int idTramite, ref Tuple<List<SmcValidaDataServidor>,string> entrada
            , ref ResultadoDTO<int> salida)
        {
            var parametros = $"ValidadoresEscrituraTramite Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "ValidarDatosClienteTramiteEditViewModel" },
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

            if (idTramite > 0) 
            {
                var existeTramiteTmp = lsValidacion.FirstOrDefault(fod => fod.CLAVE == "EXISTETRAMITE");
                if (existeTramiteTmp == null)
                {
                    using (_logger.BeginScope(props))
                    {
                        _logger.LogError($"La clave EXISTEBENEFICIARIO no se encuentra en la BD.");
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
            }

            var existeBeneficiarioTmp = lsValidacion.FirstOrDefault(fod => fod.CLAVE == "EXISTEBENEFICIARIO");
            if (existeBeneficiarioTmp == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La clave EXISTEBENEFICIARIO no se encuentra en la BD.");
                }
                salida.mensaje = "Se produjo un error Interno en la aplicación. (7)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (!existeBeneficiarioTmp.VALORBOOLEANO)
            {
                lsMensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSERV",
                    descripcion = "El Beneficiario indicado en el trámite no existe.",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;
                salida.mensaje = "El Beneficiario indicado en el trámite no existe.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            /*

            var existeDireccionTmp = lsValidacion.FirstOrDefault(fod => fod.CLAVE == "EXISTEDIRECCION");
            if (existeDireccionTmp == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La clave EXISTEDIRECCION no se encuentra en la BD.");
                }
                salida.mensaje = "Se produjo un error Interno en la aplicación. (7)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (!existeDireccionTmp.VALORBOOLEANO)
            {
                lsMensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSERV",
                    descripcion = "La dirección indicada en el trámite no existe.",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;
                salida.mensaje = "La dirección indicada en el trámite no existe.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            var existeEstadoTmp = lsValidacion.FirstOrDefault(fod => fod.CLAVE == "EXISTEESTADO");
            if (existeEstadoTmp == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"La clave EXISTEESTADO no se encuentra en la BD.");
                }
                salida.mensaje = "Se produjo un error Interno en la aplicación. (7)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (!existeEstadoTmp.VALORBOOLEANO)
            {
                lsMensajes.Add(new Mensaje
                {
                    codigo = "VLNVALSERV",
                    descripcion = "El estado indicado en el trámite no existe.",
                    tipo = "ADVERTENCIA"
                });
                salida.mensajes = lsMensajes;
                salida.mensaje = "El estado indicado en el trámite no existe.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            */
            if (idTramite > 0)
            {
                var existeTipoContratoTmp = lsValidacion.FirstOrDefault(fod => fod.CLAVE == "EXISTETIPOCONTRATO");
                if (existeTipoContratoTmp == null)
                {
                    using (_logger.BeginScope(props))
                    {
                        _logger.LogError($"La clave EXISTETIPOCONTRATO no se encuentra en la BD.");
                    }
                    salida.mensaje = "Se produjo un error Interno en la aplicación. (7)";
                    salida.tipo = "ADVERTENCIA";
                    return puedeContinuar;
                }

                if (!existeTipoContratoTmp.VALORBOOLEANO)
                {
                    lsMensajes.Add(new Mensaje
                    {
                        codigo = "VLNVALSERV",
                        descripcion = "El Tipo de Contrato indicado en el trámite no existe.",
                        tipo = "ADVERTENCIA"
                    });
                    salida.mensajes = lsMensajes;
                    salida.mensaje = "El Tipo de Contrato indicado en el trámite no existe.";
                    salida.tipo = "ADVERTENCIA";
                    return puedeContinuar;
                }
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}