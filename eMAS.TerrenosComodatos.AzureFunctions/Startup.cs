using eMAS.Api.TerrenosComodatos.Data;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic.Communication;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.Repository;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

[assembly: FunctionsStartup(typeof(eMAS.TerrenosComodatos.AzureFunctions.Startup))]
namespace eMAS.TerrenosComodatos.AzureFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            builder.Services.AddDbContext<COMODATOContext>(ServiceLifetime.Transient);
            // transient services with your business logic
            builder.Services.AddTransient<IServiceNotificationTramiteOficio, ServiceNotificationTramiteOficio>();

            builder.Services.AddTransient<CatalogoLogic>();
            builder.Services.AddTransient<NotificacionLogic>();
            builder.Services.AddTransient<MailLogic>();
            builder.Services.AddTransient<IGestionRepositorioLecturaCatalogo, RepositorioCatalogo>();
            builder.Services.AddTransient<IGestionRepositorioLecturaNotificacionOficio, RepositorioNotificacion>();

            builder.Services.AddOptions<MailSettings>()
            .Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection(nameof(MailSettings)).Bind(settings);
            });
        }
    }
}
