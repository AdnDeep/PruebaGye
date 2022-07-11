using eMAS.TerrenosComodatos.Domain.Application;
using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using eMAS.TerrenosComodatos.Infrastructure;
using eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;

namespace eMAS.TerrenosComodatos.Web
{
    public static class ServicesExtensions
    {
        public static void AddSettingsApp(this IServiceCollection services, IConfiguration Configuration)
        {
            AppSettings appSettings = new AppSettings();
            services.Configure<AppSettings>(
                    Configuration.GetSection(AppSettings.Titulo));
        }

        public static void AddServicesExtensions(this IServiceCollection services)
        {
            // Api Service
            services.AddTransient<ApiService>();
            services.AddHttpClient();

            // Casos de Uso
            services.AddTransient<ICasesUsesGestionBeneficiario, CasesUsesGestionBeneficiario>();
            services.AddTransient<ICasesUsesGestionTramite, CasesUsesGestionTramite>();
            services.AddTransient<ICasesUsesGeneric, CasesUsesGeneric>();

            // Mapeadores
            services.AddTransient<MapeadoresBeneficiario>();
            services.AddTransient<MapeadoresGenerico>();
            services.AddTransient<MapeadoresTramite>();
            // Validadores
            services.AddTransient<ValidadoresBeneficiario>();
            services.AddTransient<ValidadoresGenerico>();
            services.AddTransient<ValidadoresTramite>();
            // Repositorios
            services.AddTransient<IGestionRepositorioExternoTramite, GestionRepositorioExternoTramite>();
            services.AddTransient<IGestionRepositorioExternoGenerico, GestionRepositorioExternoGenerico>();
            services.AddTransient<IGestionRepositorioExternoBeneficiario, GestionRepositorioExternoBeneficiario>();
        }

        public static void AddServicesAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMicrosoftIdentityWebAppAuthentication(Configuration)
                    .EnableTokenAcquisitionToCallDownstreamApi()
                    .AddInMemoryTokenCaches();
        }
    }
}
