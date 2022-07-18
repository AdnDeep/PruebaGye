using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresTramite
    {
        public bool DataClienteEliminacionDetalle<T>(short id, ref ResultadoDTO<T> salida)
        {
            bool puedeContinuar = false;

            if (id <= 0)
            {
                _logger.LogError($"El objeto Respuesta desde el cliente para eliminar es incorrecto, menor igual que 0 (2)");
                salida.mensaje = "No hay datos correctos para eliminar. (2)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
