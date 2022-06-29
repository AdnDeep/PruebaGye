﻿using eMAS.TerrenosComodatos.Domain.Application.CaseUses;
using eMAS.TerrenosComodatos.Domain.Application.CaseUses.Mappers;
using eMAS.TerrenosComodatos.Domain.Application.CaseUses.Validations;
using eMAS.TerrenosComodatos.Domain.Auxiliars;
using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using eMAS.TerrenosComodatos.Infrastructure.Repositories;
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
            services.AddTransient<ICaseUseLecturaBeneficiario, CaseUseLecturaBeneficiario>();
            services.AddTransient<ICaseUseEscribirBeneficiario, CaseUseEscribirBeneficiario>();
            services.AddTransient<ICaseUseEliminarBeneficiario, CaseUseEliminarBeneficiario>();
            // Entidades
            services.AddTransient<Beneficiario>();
            
            // Mapeadores
            services.AddTransient<CaseUseLecturaBeneficiarioMapeadores>();
            services.AddTransient<CaseUseEscrituraBeneficiarioMapeadores>();
            services.AddTransient<CaseUseEliminacionBeneficiarioMapeadores>();

            // Validadores
            services.AddTransient<CaseUseLecturaBeneficiarioValidadores>();
            services.AddTransient<CaseUseEscrituraBeneficiarioValidadores>();
            services.AddTransient<CaseUseEliminacionBeneficiarioValidadores>();

            // DataProvider
            services.AddTransient<GenericDataProvider>();
            services.AddTransient<ValidateDataProvider>();

            // Repositorios
            services.AddTransient<IGestionRepositorioEliminacionBeneficiario, GestionRepositorioEliminacionBeneficiario>();
            services.AddTransient<IGestionRepositorioValidacionesBeneficiario, GestionRepositorioValidacionesBeneficiario>();
            services.AddTransient<IGestionRepositorioEscrituraBeneficiario, GestionRepositorioEscrituraBeneficiario>();
            services.AddTransient<IGestionRepositorioLecturaBeneficiario, GestionRepositorioLecturaBeneficiario>();
            services.AddTransient<IGestionRepositorioLecturaGenerica, GestionRepositorioLecturaGenerica>();
        }
    }
}
