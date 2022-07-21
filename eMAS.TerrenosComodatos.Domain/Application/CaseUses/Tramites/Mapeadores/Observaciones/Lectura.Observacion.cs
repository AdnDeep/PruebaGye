using eMAS.TerrenosComodatos.Domain.Constantes;
using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresTramite
    {
        public void DataLecturaObservacion(ref ResultadoDTO<ObservacionTramiteEditViewModel> entrada)
        {
            ObservacionTramiteEditViewModel tmp = entrada.dataresult;
            tmp.strfecha = tmp.fecha.ToString(AppConst.formatoFechaDefecto);
        }
    }
}
