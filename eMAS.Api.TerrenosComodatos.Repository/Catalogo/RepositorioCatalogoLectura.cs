using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Text.Json;
using eMAS.Api.TerrenosComodatos.IRepository;
using System.Threading.Tasks;
using eMAS.Api.TerrenosComodatos.Comun;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace eMAS.Api.TerrenosComodatos.Repository
{
    public partial class RepositorioCatalogo : IGestionRepositorioLecturaCatalogo
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RepositorioCatalogo> _logger;
        public RepositorioCatalogo(
            IServiceProvider serviceProvider
            , ILogger<RepositorioCatalogo> logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<List<SmcCatalogoConfiguracion>> GetCatalogoPorCodigoYTipo(string codigo, string tipo, string claveBusqueda1, string claveBusqueda2)
        {
            List<SmcCatalogoConfiguracion> lsResultado = new List<SmcCatalogoConfiguracion>();
            
            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                lsResultado = await db.SmcCatalogosConfiguracion.FromSqlInterpolated(@$"SmcPr_SmcCatalogo_GetValoresPorCodigoYTipo
                                 @Codigo =  {codigo},
                                 @Tipo = {tipo},
                                 @ClaveBusqueda1 = {claveBusqueda1},
                                 @ClaveBusqueda2 = {claveBusqueda2}").ToListAsync();
            }
            return lsResultado;
        }
    }
}