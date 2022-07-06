
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresBeneficiario
    {
        public void RespuestaServidorDataPaginada(ref ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> entrada
            , ref ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> salida)
        {
            salida.tipo = entrada.tipo;
            salida.mensaje = entrada.mensaje;
            salida.dataresult = entrada.dataresult;
        }
    }
}
