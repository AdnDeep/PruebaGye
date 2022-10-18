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
    public partial class RepositorioNotificacion : IGestionRepositorioLecturaNotificacionOficio
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RepositorioNotificacion> _logger;
        public RepositorioNotificacion(
            IServiceProvider serviceProvider
            , ILogger<RepositorioNotificacion> logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        public async Task<List<SmcNotificacionPendiente>> GetPendientesRespuesta()
        {
            List<SmcNotificacionPendiente> lsResultado = new List<SmcNotificacionPendiente>();

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                lsResultado = await db.SmcNotificacionPendientes
                                        .FromSqlInterpolated(@$"SmcPr_SmcOficioOtrasDirecciones_GetPendientesSinRespuesta")
                                        .ToListAsync();
            }

            return lsResultado;
        }
    }
}