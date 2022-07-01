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
    public partial class RepositorioTramiteEscritura : IGestionRepositorioEscrituraTramites
    {
        public Tuple<List<SmcValidaDataServidor>, string> GetDataValidation(string paramFilter, string objObtieneDataValidacion)
        {
            string sMensaje = string.Empty;
            List<SmcValidaDataServidor> lsEntidadValidacion = new List<SmcValidaDataServidor>();
            Tuple<List<SmcValidaDataServidor>, string> data = null;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                lsEntidadValidacion = db.SmcValidaDatasServidor.FromSqlInterpolated(@$"{objObtieneDataValidacion}
                                     @validate_filter =  {paramFilter},
                                     @Mensaje = {mensaje} OUTPUT").ToList();

                sMensaje = mensaje.Value?.ToString();
            }
            data = new Tuple<List<SmcValidaDataServidor>, string>(lsEntidadValidacion, sMensaje);

            return data;
        }
    }
}
