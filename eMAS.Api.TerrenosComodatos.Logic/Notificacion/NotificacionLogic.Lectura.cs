using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.Logic
{
    public partial class NotificacionLogic
    {
        private readonly IGestionRepositorioLecturaNotificacionOficio _repositorioNotificacionOficioLectura;
        public NotificacionLogic(IGestionRepositorioLecturaNotificacionOficio repositorioNotificacionOficioLectura)
        {
            _repositorioNotificacionOficioLectura = repositorioNotificacionOficioLectura;
        }
        public Task<List<SmcNotificacionPendiente>> ObtenerTramiteOficioPendienteSinRespuesta()
        {
            var resultadoBD = _repositorioNotificacionOficioLectura.GetPendientesRespuesta();

            return resultadoBD;
        }
    }
}
