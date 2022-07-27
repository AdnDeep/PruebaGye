using eMAS.TerrenosComodatos.Domain.DTOs;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresTramite
    {
        public void RespuestaServidorDetailList<T>(ref ResultadoDTO<T> entrada
            , ref ResultadoDTO<T> salida)
        {
            salida.tipo = entrada.tipo;
            salida.mensaje = entrada.mensaje;
            salida.dataresult = entrada.dataresult;
        }
    }
}