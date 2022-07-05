using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresBeneficiario
    {
        public bool DataClienteEscritura(ref BeneficiarioEditViewModel entrada, ref ResultadoDTO<int> salida)
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
