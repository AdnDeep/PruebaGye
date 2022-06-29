using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses.Validations
{
    public class CaseUseEliminacionBeneficiarioValidadores
    {
        private readonly ILogger<CaseUseEliminacionBeneficiarioValidadores> _logger;
        public CaseUseEliminacionBeneficiarioValidadores(ILogger<CaseUseEliminacionBeneficiarioValidadores> logger)
        {
            _logger = logger;
        }
        public bool ValidarDatosEliminacionServidorGestionRepositorio(ref ResultadoDTO<string> entrada, ref ResultadoDTO<string> salida)
        {
            bool puedeContinuar = false;

            if (entrada == null)
            {
                _logger.LogError($"El objeto Respuesta desde el servidor para eliminar es Nulo. (1)");
                salida.mensaje = "Se produjo un error al eliminar los datos en el Aplicativo. (1)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.dataresult) || string.IsNullOrWhiteSpace(entrada.dataresult))
            {
                _logger.LogError($"El objeto Respuesta desde el Servidor para eliminar está vacío (2)");
                salida.mensaje = "Se produjo un error al eliminar los datos en el Aplicativo. (2)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            var mensajeInternoBD = entrada.mensajes?.FirstOrDefault(fod => fod.codigo == "GRBIMPLELMINT001")?.descripcion;
            if (!(string.IsNullOrEmpty(mensajeInternoBD) || string.IsNullOrWhiteSpace(mensajeInternoBD)))
            {
                _logger.LogError($"Error BD al consumir metodo para eliminar (3). {mensajeInternoBD}");
                salida.mensaje = "Se produjo un error al eliminar los datos en el Aplicativo. (3)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.dataresult != "OK")
            {
                _logger.LogError($"Error BD al consumir metodo para eliminar (4) . {entrada.dataresult}");
                salida.mensaje = "Hay errores internos con los datos de la aplicacion. (4)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            puedeContinuar = true;
            return puedeContinuar;
        }
        public bool ValidarDatosEliminacionClienteBeneficiario(ref BeneficiarioDeleteModel model, ref ResultadoDTO<string> salida)
        {
            bool puedeContinuar = false;

            if (model == null) 
            {
                _logger.LogError($"El objeto Respuesta desde el cliente para eliminar es Nulo. (1)");
                salida.mensaje = "No hay datos correctos para eliminar. (1)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (model.id == 0)
            {
                _logger.LogError($"El objeto Respuesta desde el cliente para eliminar es 0 (1)");
                salida.mensaje = "No hay datos correctos para eliminar. (2)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
