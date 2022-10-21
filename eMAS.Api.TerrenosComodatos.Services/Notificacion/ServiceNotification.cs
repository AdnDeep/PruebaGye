

using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.Logic.Communication;

using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.IServices
{
    public partial class ServiceNotificationTramiteOficio : IServiceNotificationTramiteOficio
    {
        private readonly MailLogic _mailLogic;
        private readonly CatalogoLogic _catalogoLogic;
        private readonly NotificacionLogic _notificacionLogic;
        //private readonly RenderViewService _razorViewService;

        public ServiceNotificationTramiteOficio(CatalogoLogic catalogoLogic
            , NotificacionLogic notificacionLogic
            , MailLogic mailLogic
            )
        {
            this._catalogoLogic = catalogoLogic;
            this._notificacionLogic = notificacionLogic;
            this._mailLogic = mailLogic;
        }
        public async Task ObtenerOficiosSinRespuestaYNotificar(string pathBase)
        {
            Task<List<SmcCatalogoConfiguracion>> taskConfCorreoDestinatario = _catalogoLogic.ObtenerCatalogoPorCodigoYTipo("EMAIL_RECEPTOR", "CONFIGURACION", "RECNOTOFIC", "");
            Task<List<SmcNotificacionPendiente>> taskNotificacionesPendiente = _notificacionLogic.ObtenerTramiteOficioPendienteSinRespuesta();

            await Task.WhenAll(taskConfCorreoDestinatario, taskNotificacionesPendiente);

            if (taskNotificacionesPendiente == null)
                return;
            if (taskConfCorreoDestinatario == null)
                return;
            if (taskNotificacionesPendiente.Result == null)
                return;
            if (taskConfCorreoDestinatario.Result == null)
                return;

            var lsResultNotificacionPendiente = taskNotificacionesPendiente.Result;
            var lsResultDestinatarios = taskConfCorreoDestinatario.Result;

            if (lsResultNotificacionPendiente.Count == 0)
                return;
            if (lsResultDestinatarios.Count == 0)
                return;

            var mailTo = lsResultDestinatarios.Select(s => s.ValorAlfaNumerico1).ToList();

            string emailTemplate = _mailLogic.GetEmailTemplate<List<SmcNotificacionPendiente>>("NotificacionOficiosPendientes", pathBase, lsResultNotificacionPendiente);

            string fecha = DateTime.Now.ToString("yyyy-MMMM-dd");
            string subject = $"Sistema Comodato Notificaciones para Tramites Oficios {fecha}";


            MailData mailData = new MailData(mailTo, subject, emailTemplate);
            
            await _mailLogic.SendAsync(mailData);
        }
    }
}
