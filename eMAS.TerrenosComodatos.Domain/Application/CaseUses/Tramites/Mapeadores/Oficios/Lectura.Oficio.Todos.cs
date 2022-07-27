
using eMAS.TerrenosComodatos.Domain.Constantes;
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresTramite
    {
        public void DataLecturaTodosOficio(ref ResultadoDTO<List<OficioTramiteListViewModel>> entrada)
        {
            List<OficioTramiteListViewModel> lsObservacion = entrada.dataresult;
            foreach (var det in lsObservacion)
            {
                det.strfechaenvio = det.fechaenvio != null ? det.fechaenvio.Value.ToString(AppConst.formatoFechaDefecto) : "";
                det.strfecharespuesta = det.fecharespuesta != null ? det.fecharespuesta.Value.ToString(AppConst.formatoFechaDefecto) : "";
            }            
        }
    }
}
