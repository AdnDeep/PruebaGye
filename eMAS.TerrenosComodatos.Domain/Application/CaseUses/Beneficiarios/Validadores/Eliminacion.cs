using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses
{
    public partial class ValidadoresBeneficiario
    {
        public bool DataClienteEliminacion(ref BeneficiarioDeleteViewModel model, ref ResultadoDTO<string> salida)
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
