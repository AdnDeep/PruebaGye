using eMAS.Api.TerrenosComodatos.Data;
using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using System.Data;
using eMAS.Api.TerrenosComodatos.IRepository;

namespace eMAS.Api.TerrenosComodatos.Repository
{
    public class RepositorioBeneficiarioValidacion : IRepositorioBeneficiarioValidacion
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositorioBeneficiarioValidacion(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Tuple<List<SmcValidacionEscritura>, string> ValidarEscritura(BeneficiariosValidacion1Filter validacionFilter)
        {
            string sMensaje = string.Empty;
            List<SmcValidacionEscritura> lsEntidadValidacion = new List<SmcValidacionEscritura>();
            Tuple<List<SmcValidacionEscritura>, string> data = null;

            var panelFilterParameter = new
            {
                Id = validacionFilter.Id,
                nombre = validacionFilter.nombre
            };
            string strBenficiarioFilterParameter = JsonSerializer.Serialize(panelFilterParameter);

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                lsEntidadValidacion = db.SmcValidacionsEscritura.FromSqlInterpolated(@$"SmcPr_SmcBeneficiario_GetDataValidationBeneficiarios1
                                     @BeneficiarioFilter =  {strBenficiarioFilterParameter},
                                     @Mensaje = {mensaje} OUTPUT").ToList();

                sMensaje = mensaje.Value?.ToString();
            }
            data = new Tuple<List<SmcValidacionEscritura>, string>(lsEntidadValidacion, sMensaje);

            return data;
        }
    }
}
