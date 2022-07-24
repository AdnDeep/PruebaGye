using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        private readonly string _baseAddress;
        private readonly ILogger<GestionRepositorioExternoTramite> _logger;
        const string methodGetPaged = "api/GestionTramite/ObtenerListadoPorPagina";
        const string methodGetById = "api/GestionTramite/ObtenerPorId";
        const string methodPost = "api/GestionTramite/Agregar";
        const string methodPut = "api/GestionTramite/Actualizar";
        const string methodDelete = "api/GestionTramite/Eliminar";
        const string methodReporteGeneralPdf = "api/PrintPdf/GetSingleTramiteDsr";

        private readonly ApiService _clientHttpSvc;
        public GestionRepositorioExternoTramite(ApiService clientHttpSvc
            , IConfiguration configuration
            , ILogger<GestionRepositorioExternoTramite> logger)
        {
            _logger = logger;
            _baseAddress = configuration["ApiComodato:ApiBaseAddress"];
            _clientHttpSvc = clientHttpSvc;
        }
    }
}
