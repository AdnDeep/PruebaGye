using Microsoft.Extensions.Configuration;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Data;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.Repository;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.Logic.Communication;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;


namespace eMAS.TerrenosComodatos.ServiciosWindows
{
    public static class Bootstrapper
    {
        public static IHostBuilder AddLogging(this IHostBuilder host)
        {
            host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });
            return host;
        }

        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            string environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

            host.ConfigureAppConfiguration((_, configuration) =>
            {
                configuration.Sources.Clear();

                configuration
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false);
            });
            return host;
        }
        
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices((hostingContext, services) =>
            {
                var configurationRoot = hostingContext.Configuration;

                // the hosted service (a singleton) that wrap the console logic that allows DI
                services.AddHostedService<NotificacionOficioHostedService>();

                services.AddDbContext<COMODATOContext>(ServiceLifetime.Transient);
                // transient services with your business logic
                services.AddTransient<INotificationTramiteOficioJob, NotificationTramiteOficioJob>();
                services.AddTransient<IServiceNotificationTramiteOficio, ServiceNotificationTramiteOficio>();

                services.AddTransient<CatalogoLogic>();
                services.AddTransient<NotificacionLogic>();
                services.AddTransient<MailLogic>();
                services.AddTransient<IGestionRepositorioLecturaCatalogo, RepositorioCatalogo>();
                services.AddTransient<IGestionRepositorioLecturaNotificacionOficio, RepositorioNotificacion>();
                services.Configure<MailSettings>(configurationRoot.GetSection(key: nameof(MailSettings)));
                services.AddApplicationInsightsTelemetryWorkerService();
            });
            return host;
        }
    }
}
