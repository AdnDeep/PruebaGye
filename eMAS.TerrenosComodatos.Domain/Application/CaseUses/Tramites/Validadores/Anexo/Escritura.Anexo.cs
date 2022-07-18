using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresTramite
    {
        public bool DataClienteEscrituraAnexo(ref AnexoTramiteEditViewModel entrada, ref ResultadoDTO<int> salida)
        {
            bool puedeContinuar = false;
            salida.tipo = "EXITO";
            salida.mensaje = "OK";
            if (entrada == null)
            {
                salida.mensaje = "No hay datos para guardar. (1)";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.link) || string.IsNullOrWhiteSpace(entrada.link))
            {
                salida.mensaje = "Indicar un enlace es Obligatorio.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            
            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
