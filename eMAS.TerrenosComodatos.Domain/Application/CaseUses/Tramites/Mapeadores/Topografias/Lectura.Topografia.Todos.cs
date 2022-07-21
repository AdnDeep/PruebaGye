using eMAS.TerrenosComodatos.Domain.Constantes;
using eMAS.TerrenosComodatos.Domain.DTOs;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresTramite
    {
        public void DataLecturaTodosTopografia(ref ResultadoDTO<List<TopografiaTerrenoListViewMoel>> entrada)
        {
            List<TopografiaTerrenoListViewMoel> lsObservacion = entrada.dataresult;
            foreach (var det in lsObservacion)
            {
                det.strfechaenvio = det.fechaenvio != null ? det.fechaenvio.Value.ToString(AppConst.formatoFechaDefecto) : "";
                det.strfecharespuesta = det.fecharespuesta != null ? det.fecharespuesta.Value.ToString(AppConst.formatoFechaDefecto) : "";
            }            
        }
    }
}
