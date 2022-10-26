using System;
using System.Threading.Tasks;
using eMAS.Api.TerrenosComodatos.IServices;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace eMAS.TerrenosComodatos.AzureFunctions
{
    public class FunctionTramiteOficio
    {
        private readonly IOptions<ExecutionContextOptions> _executionContext;

        private IServiceNotificationTramiteOficio _serviceNotificationTramiteOficio;
        public FunctionTramiteOficio(IServiceNotificationTramiteOficio serviceNotificationTramiteOficio
            , IOptions<ExecutionContextOptions> executionContext)
        {
            this._serviceNotificationTramiteOficio = serviceNotificationTramiteOficio;
            this._executionContext = executionContext;
        }
        [FunctionName("FnNotificacionOficiosSinRespuesta")]
        public async Task Run([TimerTrigger("0 /1 0 * * 1-5")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var context = _executionContext.Value;
            var rootDir = context.AppDirectory; 

            await _serviceNotificationTramiteOficio.ObtenerOficiosSinRespuestaYNotificar(rootDir);
            //
        }
    }
}
