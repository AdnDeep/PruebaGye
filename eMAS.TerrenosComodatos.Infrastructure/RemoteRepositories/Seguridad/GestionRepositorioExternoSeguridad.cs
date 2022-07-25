using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoSeguridad : IGestionRepositorioExternoSeguridad
    {
        private readonly string _baseAddress;
        private readonly ILogger<GestionRepositorioExternoSeguridad> _logger;
        const string resourceSeguridad = "AzureAdLogin:ResourceSeguridad";
        const string methodGetPermisoByUsuario = "api/Usuario/VerificarAcceso";

        private readonly ApiService _clientHttpSvc;
        public GestionRepositorioExternoSeguridad(ApiService clientHttpSvc
            , IConfiguration configuration
            , ILogger<GestionRepositorioExternoSeguridad> logger)
        {
            _logger = logger;
            _baseAddress = configuration["ApiSeguridad:ApiBaseAddress"];
            _clientHttpSvc = clientHttpSvc;
        }
    }
}
