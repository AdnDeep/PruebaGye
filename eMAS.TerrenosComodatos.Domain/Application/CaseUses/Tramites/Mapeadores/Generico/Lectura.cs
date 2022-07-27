
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresTramite
    {
        public void GenerateEditViewModelDetailEmpty<T>(ref T model)
        {
            var prop = model.GetType().GetProperty("idtramite", BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(model, 0, null);

            }
        }
        public void GenerateEditViewModelDetail<T>(ref ResultadoDTO<T> model
            , ref ResultadoDTO<T> salida)
        {
            salida.tipo = model.tipo;
            salida.mensaje = model.mensaje;
            salida.dataresult = model.dataresult;
        }
    }
}
