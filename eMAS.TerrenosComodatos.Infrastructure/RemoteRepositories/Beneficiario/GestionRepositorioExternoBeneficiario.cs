using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoBeneficiario : IGestionRepositorioExternoBeneficiario
    {
        private readonly string _baseAddress;
        private readonly ILogger<GestionRepositorioExternoBeneficiario> _logger;
        const string methodGetPaged = "api/GestionBeneficiario/ObtenerListadoPorPagina";
        private readonly ApiService _clientHttpSvc;
        public GestionRepositorioExternoBeneficiario(ApiService clientHttpSvc
            , IConfiguration configuration
            , ILogger<GestionRepositorioExternoBeneficiario> logger)
        {
            _logger = logger;
            _baseAddress = configuration["ApiComodato:ApiBaseAddress"];
            _clientHttpSvc = clientHttpSvc;
        }
    }
}
