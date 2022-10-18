using eMAS.Api.TerrenosComodatos.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.ServiciosWindows
{
    public interface INotificationTramiteOficioJob
    {
        Task Execute();
    }
    public class NotificationTramiteOficioJob : INotificationTramiteOficioJob
    {
        private IServiceNotificationTramiteOficio serviceNotificationTramiteOficio;
        public NotificationTramiteOficioJob(IServiceNotificationTramiteOficio _serviceNotificationTramiteOficio)
        {
            this.serviceNotificationTramiteOficio = _serviceNotificationTramiteOficio;
        }
        public async Task Execute()
        {
            // Obtener Lista de Tramites Sin Oficio Dentro de un Período
            await serviceNotificationTramiteOficio.ObtenerOficiosSinRespuestaYNotificar();

        }
    }
}
