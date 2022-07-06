using eMAS.TerrenosComodatos.Domain.Application;
using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eMAS.TerrenosComodatos.Web.Extensions
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
            // Casos de Uso
            services.AddTransient<ICasesUsesGestionBeneficiario, CasesUsesGestionBeneficiario>();
            services.AddTransient<ICasesUsesGestionTramite, CasesUsesGestionTramite>();
            services.AddTransient<ICasesUsesGeneric, CasesUsesGeneric>();

            // Mapeadores
            services.AddTransient<MapeadoresBeneficiario>();

            // Validadores
            services.AddTransient<ValidadoresBeneficiario>();

            // Repositorios
            services.AddTransient<IGestionRepositorioExternoTramite, GestionRepositorioExternoTramite>();
            services.AddTransient<IGestionRepositorioExternoGenerico, GestionRepositorioExternoGenerico>();
            services.AddTransient<IGestionRepositorioExternoBeneficiario, GestionRepositorioExternoBeneficiario>();
        }
    }
}
