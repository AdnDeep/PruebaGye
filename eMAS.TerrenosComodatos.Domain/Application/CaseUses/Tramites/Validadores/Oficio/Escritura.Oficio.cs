using eMAS.TerrenosComodatos.Domain.Constantes;
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class ValidadoresTramite
    {
        public bool DataClienteEscrituraOficio(ref OficioTramiteEditViewModel entrada, ref ResultadoDTO<int> salida)
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
            if (entrada.iddireccion <= 0)
            {
                salida.mensaje = "Indicar una Dirección es Obligatorio.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (string.IsNullOrEmpty(entrada.oficio) || string.IsNullOrWhiteSpace(entrada.oficio))
            {
                salida.mensaje = "Indicar una oficio es Obligatorio.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.fechaenvio == null)
            {
                salida.mensaje = "Indicar una Fecha de Envio es Obligatorio.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (entrada.fechaenvio.Value.Year < AppConst.anioMinimoMimg)
            {
                salida.mensaje = "La fecha de Envio tiene que ser mayor que la fecha minima.";
                salida.tipo = "ADVERTENCIA";
                return puedeContinuar;
            }
            if (!(string.IsNullOrEmpty(entrada.oficiorespuesta) || string.IsNullOrWhiteSpace(entrada.oficiorespuesta)))
            {
                if (entrada.fecharespuesta == null)
                {
                    salida.mensaje = "Debe Indicar una Fecha de Respuesta.";
                    salida.tipo = "ADVERTENCIA";
                    return puedeContinuar;
                }
                if (entrada.fecharespuesta.Value.Year < AppConst.anioMinimoMimg)
                {
                    salida.mensaje = "La fecha de respuesta tiene que ser mayor que la fecha minima.";
                    salida.tipo = "ADVERTENCIA";
                    return puedeContinuar;
                }
            }

            puedeContinuar = true;
            return puedeContinuar;
        }
    }
}
