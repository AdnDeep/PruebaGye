using eMAS.TerrenosComodatos.Domain.DTOs;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresTramite
    {
        public void GenerateEditViewModelDetailAfterSave(ref ResultadoDTO<int> model
            , ref ResultadoDTO<int> salida, bool esNuevo)
        {
            salida.tipo = model.tipo;
            salida.mensaje = model.mensaje;
            salida.dataresult = model.dataresult;
            salida.mensajes = new List<Mensaje>();
            if(esNuevo)
                salida.mensajes.Add(new Mensaje { tipo = "TRANSACCION", codigo = "INSERTADO", descripcion = salida.dataresult.ToString() });
        }
    }
}
