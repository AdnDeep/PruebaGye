using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses.Validations
{
    public class CaseUseEscrituraBeneficiarioValidadores
    {
        private readonly ILogger<CaseUseEscrituraBeneficiarioValidadores> _logger;
        public CaseUseEscrituraBeneficiarioValidadores(ILogger<CaseUseEscrituraBeneficiarioValidadores> logger)
        {
            _logger = logger;
        }
        public bool ValidarRespuestaServidorGestionCrear(ref ResultadoDTO<string> entrada, ref ResultadoDTO<BeneficiarioEditModel> salida)
        {
            bool puedeContinuar = false;
            salida.tipo = "EXITO";
            salida.mensaje = "OK";
            if (entrada == null)
            {
                _logger.LogError($"El objeto Respuesta del servidor para la accion crear es nulo. (1)");
                salida.mensaje = "Se produjo un error en el proceso de grabar en la aplicacion. (1)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.dataresult) || string.IsNullOrWhiteSpace(entrada.dataresult))
            {
                _logger.LogError($"El objeto Respuesta del servidor para la accion crear es nulo. (2)");
                salida.mensaje = "Se produjo un error en el proceso de grabar en la aplicacion. (2)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }            
            var mensajeInternoBD = entrada.mensajes?.FirstOrDefault(fod => fod.codigo == "GRBIMPLESCINT001")?.descripcion;
            if (!(string.IsNullOrEmpty(mensajeInternoBD) || string.IsNullOrWhiteSpace(mensajeInternoBD)))
            {
                _logger.LogError($"Error BD al consumir metodo para crear (4). {mensajeInternoBD}");
                salida.mensaje = "Se produjo un error Interno en la aplicación. (4)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.dataresult != "OK")
            {
                _logger.LogError($"Error BD al crear (5) . {entrada.dataresult}");
                salida.mensaje = "Hay errores internos con los datos de la aplicacion. (5)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool ValidarDatosServidorBeneficiarioEditModel(ref ResultadoDTO<Tuple<List<EntidadValidacion>, string>> entrada
            , ref ResultadoDTO<BeneficiarioEditModel> salida)
        {
            bool puedeContinuar = false;
            salida.tipo = "EXITO";
            salida.mensaje = "OK";
            if (entrada == null)
            {
                _logger.LogError($"No se recuperaron datos del servidor para consultar los datos de valdación de Lógica de Negocios.");
                salida.mensaje = "Se produjo un error Interno en la aplicación. (1)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.dataresult == null)
            {
                _logger.LogError($"No se recuperaron datos del servidor para consultar los datos de valdación de Lógica de Negocios. Objeto DataResult es Nulo.");
                salida.mensaje = "Se produjo un error Interno en la aplicación. (2)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.dataresult.Item2) || string.IsNullOrWhiteSpace(entrada.dataresult.Item2))
            {
                _logger.LogError($"No se recuperó mensaje correcto al consultar los datos de validación de Lógica de Negocios.");
                salida.mensaje = "Se produjo un error Interno en la aplicación. (3)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.dataresult.Item2 != "OK")
            {
                _logger.LogError($"Error BD al consultar los datos de validación de Lógica de Negocios. {entrada.mensaje}");
                salida.mensaje = "Se produjo un error Interno en la aplicación. (4)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            var mensajeInternoBD = entrada.mensajes?.FirstOrDefault(fod => fod.codigo == "GRBIMPLVALINT001")?.descripcion;
            if (!(string.IsNullOrEmpty(mensajeInternoBD) || string.IsNullOrWhiteSpace(mensajeInternoBD)))
            {
                _logger.LogError($"Error BD al consultar los datos de validación de Lógica de Negocios (2). {mensajeInternoBD}");
                salida.mensaje = "Se produjo un error Interno en la aplicación. (5)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            // Logica de Negocios
            var dataTmp = entrada.dataresult.Item1;

            if (dataTmp == null)
            {
                _logger.LogError($"El objeto de Entidad Validacion de Logica de Negocios devuelto desde la BD se encuentra nulo");
                salida.mensaje = "Se produjo un error Interno en la aplicación. (6)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            var dataNombreTmp = dataTmp.FirstOrDefault(fod => fod.clave == "NOMBRE");
            if (dataNombreTmp == null)
            {
                _logger.LogError($"La clave Nombre no se encuentra en la BD.");
                salida.mensaje = "Se produjo un error Interno en la aplicación. (7)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            if (dataNombreTmp.valorNumerico >= 1)
            {
                salida.mensaje = "El nombre a grabar ya existe en el sistema.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool ValidarDatosClienteBeneficiarioEditModel(ref BeneficiarioEditModel entrada, ref ResultadoDTO<BeneficiarioEditModel> salida)
        {
            bool puedeContinuar = false;
            salida.mensaje = "OK";
            salida.mensaje = "OK";
            if (entrada == null)
            {
                salida.mensaje = "No hay datos para guardar. (1)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.nombre) || string.IsNullOrWhiteSpace(entrada.nombre))
            {
                salida.mensaje = "El Nombre del Beneficiario es un campo obligatorio. (2)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
