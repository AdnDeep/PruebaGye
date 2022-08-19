﻿using eMAS.Api.Comun.Lib;
using eMAS.Api.TerrenosComodatos.Data;
using eMAS.Api.TerrenosComodatos.Extensions;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.Logic.Generic;
using eMAS.Api.TerrenosComodatos.Repository;
using eMAS.Api.TerrenosComodatos.Services;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using NSwag;
using NSwag.Generation.Processors.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using OpenApiInfo = Microsoft.OpenApi.Models.OpenApiInfo;

namespace eMAS.Api.TerrenosComodatos
{
    public static class ServiceExtension
    {
        public static void AddHttpServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
        }

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
                options.IdleTimeout = TimeSpan.FromMinutes(5);
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
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "MIMG Dirección Informática",
                            Email = "vicman@gmail.com" 
                        },
                        Version = "v1" 
                    });

                c.SwaggerDoc("vAuthorizationCode",
                    new OpenApiInfo
                    {
                        Title = "eMAS.Api.TerrenosComodatos",
                        Description = "Métodos da API para consumir Datos de Comodatos",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "MIMG Dirección Informática",
                            Email = "vicman@gmail.com"
                        },
                        Version = "AuthCode"
                    });
            });
        }
        public static void AddOpenApiDocumentation(this IServiceCollection services)
        {
            NSwag.OpenApiSecurityScheme nswagOpenApiSecurityScheme = new NSwag.OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.OAuth2,
                Description = "B2C authentication",
                Flow = OpenApiOAuth2Flow.Implicit,
                Flows = new NSwag.OpenApiOAuthFlows()
                {
                    Implicit = new NSwag.OpenApiOAuthFlow()
                    {
                        Scopes = new Dictionary<string, string>
                            {
                                { "https://test1.gye.gob.ec/d8411907-3309-4ae5-8e20-2962d40411b8/user_impersonation", "Access the api as the signed-in user" }
                            },
                        AuthorizationUrl = "https://testgye.b2clogin.com/testgye.onmicrosoft.com/oauth2/v2.0/authorize?p=B2C_1_LoginMobile",
                        TokenUrl = "https://testgye.b2clogin.com/testgye.onmicrosoft.com/oauth2/v2.0/token?pB2C_1_LoginMobile"
                    },
                }
            };
            //services.AddOpenApiDocument(document =>
            //{
            //    document.Title = "eMAS.Api.TerrenosComodatos";
            //    document.Version = "v1";
            //    document.DocumentName = "v1";
            //    document.AddSecurity("bearer", Enumerable.Empty<string>(), nswagOpenApiSecurityScheme);
            //    document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));
            //});

            services.AddOpenApiDocument(document =>
            {
                document.Title = "TerrenosComodatos-SRC-AAD-AuthCode";
                document.Version = "v1-AuthCodeAAD-SRC";
                document.DocumentName = "v1-AuthCodeAAD-SRC";
                document.ApiGroupNames = OAuthFlow.AuthCodeAAD.GetGroupNames();
                document.AddSecurity("bearer", Enumerable.Empty<string>(), nswagOpenApiSecurityScheme);
                document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));
            });

        }
        public static void AddHelperExtensions(this IServiceCollection services)
        {
            services.AddTransient<RenderViewService>();
            services.AddTransient<ServiceConvertirHtmlAPdf>();
        }
        public static void AddServicesTelemetry(this IServiceCollection services)
        {
            ApplicationInsightsServiceOptions aiOptions = new ApplicationInsightsServiceOptions();

            aiOptions.RequestCollectionOptions.TrackExceptions = true;
            services.AddApplicationInsightsTelemetry(aiOptions);

            services.AddSingleton<ITelemetryInitializer, TelemetryUser>();

        }
        public static void AddAuthenticationServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMicrosoftIdentityWebApiAuthentication(Configuration, "AzureAdB2C", "AADB2C", false);

            services
                    .AddAuthorization(options =>
                    {
                        options.DefaultPolicy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .AddAuthenticationSchemes("AADB2C")
                            .Build();
                    });
        }
        public static void AddAuthenticatinServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("ApiConfigureCC-AAD", options =>
                {
                    options.Audience = Configuration["ApiComodatoClientCredentialServer-AAD:ApplicationUri"];
                    options.Authority = Configuration["ApiComodatoClientCredentialServer-AAD:UrlAuthority"];
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidAudience = Configuration["ApiComodatoClientCredentialServer-AAD:ApplicationUri"],
                        ValidIssuer = $"{Configuration["ApiComodatoClientCredentialServer-AAD:UrlAuthority"]}/v2.0"
                    };
                })
                .AddMicrosoftIdentityWebApi(options =>
                {
                    Configuration.Bind("AzureAd", options);
                    options.TokenValidationParameters.NameClaimType = "name";
                }, options => { Configuration.Bind("AzureAd", options); });

            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                                JwtBearerDefaults.AuthenticationScheme, "ApiConfigureCC-AAD");
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }
    }
}
