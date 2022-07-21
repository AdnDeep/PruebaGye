
using eMAS.TerrenosComodatos.Domain.Constantes;
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresTramite
    {
        public void DataLecturaTodosObservacion(ref ResultadoDTO<List<ObservacionTramiteListViewModel>> entrada)
        {
            List<ObservacionTramiteListViewModel> lsObservacion = entrada.dataresult;
            foreach (var det in lsObservacion)
            {
                det.strfecha = det.fecha.ToString(AppConst.formatoFechaDefecto);
            }            
        }
    }
}
