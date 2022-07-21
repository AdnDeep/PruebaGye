using eMAS.TerrenosComodatos.Domain.Constantes;
using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresTramite
    {
        public void DataLecturaTopografia(ref ResultadoDTO<TopografiaTerrenoEditViewMoel> entrada)
        {
            TopografiaTerrenoEditViewMoel tmp = entrada.dataresult;
            tmp.strfechaenvio =tmp.fechaenvio != null?  tmp.fechaenvio.Value.ToString(AppConst.formatoFechaDefecto) :"";
            tmp.strfecharespuesta = tmp.fecharespuesta != null ? tmp.fecharespuesta.Value.ToString(AppConst.formatoFechaDefecto) : "";
        }
    }
}
