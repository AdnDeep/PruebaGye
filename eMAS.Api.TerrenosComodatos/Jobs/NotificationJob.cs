using eMAS.Api.TerrenosComodatos.IServices;
using System;

namespace eMAS.Api.TerrenosComodatos
{
    public class NotificationTramiteOficioJob : INotificationTramiteOficioJob
    {
        private IServiceNotificationTramiteOficio serviceNotificationTramiteOficio;
        public NotificationTramiteOficioJob(IServiceNotificationTramiteOficio _serviceNotificationTramiteOficio)
        {
            this.serviceNotificationTramiteOficio = _serviceNotificationTramiteOficio;
        }
        public void Execute()
        {
            Console.WriteLine("hola mundo 2");
            // Obtener Lista de Tramites Sin Oficio Dentro de un Período

            // Consumir Enqueue Job
            //serviceNotificationTramiteOficio.OficiosSinRespuesta();
        }
    }
}
