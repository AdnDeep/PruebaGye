using eMAS.TerrenosComodatos.Domain.Application;
using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using eMAS.TerrenosComodatos.Infrastructure;
using eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using System;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Web
{
    public static class ServicesExtensions
    {
        public static void AddHttpServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
        }
        public static void AddSettingsApp(this IServiceCollection services, IConfiguration Configuration)
        {
            AppSettings appSettings = new AppSettings();
            services.Configure<AppSettings>(
                    Configuration.GetSection(AppSettings.Titulo));

            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            SystemSettings systemSettings = new SystemSettings();
            systemSettings.CurrentDecimalSeparator = cultureInfo.NumberFormat.CurrencyDecimalSeparator;

            cultureInfo = null;

            services.AddSingleton<SystemSettings>(systemSettings);
        }

        public static void AddServicesExtensions(this IServiceCollection services)
        {
            // Api Service
            services.AddTransient<ApiService>();
            services.AddHttpClient();

            // Casos de Uso
            services.AddTransient<ICasesUsesGestionSeguridad, CasesUsesGestionSeguridad>();
            services.AddTransient<ICasesUsesGestionBeneficiario, CasesUsesGestionBeneficiario>();
            services.AddTransient<ICasesUsesGestionTramite, CasesUsesGestionTramite>();
            services.AddTransient<ICasesUsesGeneric, CasesUsesGeneric>();

            // Mapeadores
            services.AddTransient<MapeadoresBeneficiario>();
            services.AddTransient<MapeadoresGenerico>();
            services.AddTransient<MapeadoresTramite>();
            services.AddTransient<MapeadoresSeguridad>();
            // Validadores
            services.AddTransient<ValidadoresBeneficiario>();
            services.AddTransient<ValidadoresGenerico>();
            services.AddTransient<ValidadoresTramite>();
            services.AddTransient<ValidadoresSeguridad>();
            // Repositorios
            services.AddTransient<IGestionRepositorioExternoTramite, GestionRepositorioExternoTramite>();
            services.AddTransient<IGestionRepositorioExternoGenerico, GestionRepositorioExternoGenerico>();
            services.AddTransient<IGestionRepositorioExternoBeneficiario, GestionRepositorioExternoBeneficiario>();
            services.AddTransient<IGestionRepositorioExternoSeguridad, GestionRepositorioExternoSeguridad>();
        }

        public static void AddServicesAuthenticationAuthorization(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMicrosoftIdentityWebAppAuthentication(Configuration, "AzureAdLogin")
                    .EnableTokenAcquisitionToCallDownstreamApi()
                    .AddInMemoryTokenCaches();

            services.AddRazorPages()
                    .AddMicrosoftIdentityUI();
            services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddOptions();
            services.Configure<OpenIdConnectOptions>(Configuration.GetSection("AzureAdLogin"));
        }
        public static void AddSessionServicesExtensions(this IServiceCollection services)
        {
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
        public static void AddServicesTelemetry(this IServiceCollection services)
        {
            ApplicationInsightsServiceOptions aiOptions = new ApplicationInsightsServiceOptions();

            aiOptions.RequestCollectionOptions.TrackExceptions = true;
            services.AddApplicationInsightsTelemetry(aiOptions);

            services.AddSingleton<ITelemetryInitializer, TelemetryUser>();

        }

        public static async Task OnTicketReceivedFunc(TicketReceivedContext context)
        {
            await Task.CompletedTask.ConfigureAwait(true);
        }
    }
}
