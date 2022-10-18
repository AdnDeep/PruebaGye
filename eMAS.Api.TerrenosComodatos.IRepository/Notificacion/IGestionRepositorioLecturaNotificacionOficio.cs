using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.IRepository
{
    public interface IGestionRepositorioLecturaNotificacionOficio
    {
        Task<List<SmcNotificacionPendiente>> GetPendientesRespuesta();
    }
}
