
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresTramite
    {
        public void RespuestaServidorDataPaginada(ref ResultadoDTO<DataPagineada<TramiteListViewModel>> entrada
            , ref ResultadoDTO<DataPagineada<TramiteListViewModel>> salida)
        {
            salida.tipo = entrada.tipo;
            salida.mensaje = entrada.mensaje;
            salida.dataresult = entrada.dataresult;
        }
    }
}
