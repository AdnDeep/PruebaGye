using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.ServiciosWindows
{
    internal sealed class NotificacionOficioHostedService : IHostedService
    {
        private int? _exitCode;

        private TelemetryClient _telemetryClient;
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly INotificationTramiteOficioJob _notificationTramiteOficioJob;

        public NotificacionOficioHostedService(
            ILogger<NotificacionOficioHostedService> logger,
            IHostApplicationLifetime appLifetime,
            INotificationTramiteOficioJob notificationTramiteOficioJob, 
            TelemetryClient tc
            )
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _notificationTramiteOficioJob = notificationTramiteOficioJob;
            this._telemetryClient = tc;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var parametros = $"Servicio Hosteable NotificacionOficioHostedService";
            var props = new Dictionary<string, string>(){
                            { "Metodo", "Actualizar" },
                            { "Sitio", "COMODATO-SERVWIN" },
                            { "Parametros", parametros }
                    };

            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        await _notificationTramiteOficioJob.Execute();
                        
                        _exitCode = 0;                        
                    }
                    catch (Exception ex)
                    {
                        _telemetryClient.TrackException(ex);
                         
                        _exitCode = 1;
                    }
                    finally
                    {
                        _appLifetime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Exiting with return code: {_exitCode}");

            Environment.ExitCode = _exitCode.GetValueOrDefault(-1);
            return Task.CompletedTask;
        }
    }
}
