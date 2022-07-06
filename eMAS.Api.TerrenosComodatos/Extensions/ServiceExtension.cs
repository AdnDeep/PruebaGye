using eMAS.Api.TerrenosComodatos.Data;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.Logic.Generic;
using eMAS.Api.TerrenosComodatos.Repository;
using eMAS.Api.TerrenosComodatos.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace eMAS.Api.TerrenosComodatos
{
    public static class ServiceExtension
    {
        public static void AddServicesTramitesExtensions(this IServiceCollection services)
        {
            // Repositorios
            services.AddTransient<IGestionRepositorioLecturaTramites, RepositorioTramiteLectura>();
            services.AddTransient<IGestionRepositorioEscrituraTramites, RepositorioTramiteEscritura>();
            services.AddTransient<IGestionRepositorioEliminacionTramites, RepositorioTramiteEliminacion>();
            // Logica
            services.AddTransient<TramiteLogicLectura>();
            services.AddTransient<TramiteLogicEscritura>();
            services.AddTransient<TramiteLogicEliminacion>();

            // Servicios
            services.AddTransient<IServiceTramiteLectura, ServiceTramiteLectura>();
            services.AddTransient<IServiceTramiteEscritura, ServiceTramiteEscritura>();
            services.AddTransient<IServiceTramiteEliminacion, ServiceTramiteEliminacion>();

            // Auxiliares
            services.AddTransient<MapeadoresLecturaTramite>();
            services.AddTransient<MapeadoresEscrituraTramite>();
            services.AddTransient<MapeadoresEliminacionTramite>();

            services.AddTransient<ValidadoresLecturaTramite>();
            services.AddTransient<ValidadoresEscrituraTramite>(); 
            services.AddTransient<ValidadoresEliminacionTramite>();
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
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerDocument();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new OpenApiInfo
                    { 
                        Title = "eMAS.Api.TerrenosComodatos",
                        Description = "Métodos da API para consumir Datos de Comodatos",
                        Contact = new OpenApiContact 
                        {
                            Name = "MIMG Dirección Informática",
                            Email = "vicman@gmail.com" 
                        },
                        Version = "v1" 
                    });
            });
        }
    }
}
