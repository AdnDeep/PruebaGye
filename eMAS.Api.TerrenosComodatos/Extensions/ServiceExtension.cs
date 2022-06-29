using eMAS.Api.TerrenosComodatos.Data;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.Logic.Generic;
using eMAS.Api.TerrenosComodatos.Repository;
using eMAS.Api.TerrenosComodatos.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eMAS.Api.TerrenosComodatos
{
    public static class ServiceExtension
    {
        public static void AddServicesTramitesExtensions(this IServiceCollection services)
        {
            // Repositorios
            services.AddTransient<IGestionRepositorioLecturaTramites, RepositorioTramiteLectura>();
            // Logica
            services.AddTransient<TramiteLogicLectura>();

            // Servicios
            services.AddTransient<IServiceTramiteLectura, ServiceTramiteLectura>();

            // Auxiliares
            services.AddTransient<MapeadoresLecturaTramite>();
            services.AddTransient<ValidadoresLecturaTramite>();
            services.AddTransient<ValidadoresTramitesRequest>();
        }
        public static void AddServicesGenericExtensions(this IServiceCollection services)
        {
            // Repositorios
            services.AddTransient<IGenericRepository, GenericRepository>();
            
            // Logica
            services.AddTransient<DataProviderLogicGeneric>();
            
            // Servicios
            services.AddTransient<IServiceDataProviderGeneric, ServiceDataProviderGeneric>();
            
            // Auxiliares
            services.AddTransient<MapeadoresGeneric>();
            services.AddTransient<ValidadoresGeneric>();
            services.AddTransient<ValidadoresGenericRequest>();
        }
        public static void AddServicesBeneficiariosExtensions(this IServiceCollection services)
        {
            // Contextos
            services.AddDbContext<COMODATOContext>(ServiceLifetime.Transient);

            // Repositorios
            services.AddTransient<IRepositorioBeneficiarioLectura, RepositorioBeneficiarioLectura>();
            services.AddTransient<IRepositorioBeneficiarioEscritura, RepositorioBeneficiarioEscritura>();
            services.AddTransient<IRepositorioBeneficiarioValidacion, RepositorioBeneficiarioValidacion>();
            services.AddTransient<IRepositorioBeneficiarioEliminacion, RepositorioBeneficiarioEliminacion>();
            // Logica
            services.AddTransient<BeneficiarioLogicLectura>();
            services.AddTransient<BeneficiarioLogicEscritura>();
            services.AddTransient<BeneficiarioLogicEliminacion>();
            services.AddTransient<BeneficiarioLogicValidacion>();
            services.AddTransient<ValidadoresBeneficiariosRequest>();

            // Servicios
            services.AddTransient<IServiceBeneficiarioLecturaTodos, ServiceBeneficiarioLecturaTodos>();
            services.AddTransient<IServiceBeneficiarioEscritura, ServiceBeneficiarioEscritura>();
            services.AddTransient<IServiceBeneficiarioEliminacion, ServiceBeneficiarioEliminacion>();

            // Auxiliares
            services.AddTransient<MapeadoresEliminacionBeneficiario>();
            services.AddTransient<MapeadoresEscrituraBeneficiario>();
            services.AddTransient<MapeadoresLecturaBeneficiario>();
            services.AddTransient<ValidadoresEliminar>();
            services.AddTransient<ValidadoresEscrituraBeneficiarios>();
            services.AddTransient<ValidadoresLecturaBeneficiarios>();
        }
        public static void AddSessionServicesExtensions(this IServiceCollection services)
        {
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
    }
}
