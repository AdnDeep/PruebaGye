using eMAS.Api.TerrenosComodatos.Data;
using eMAS.Api.TerrenosComodatos.IRepository;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;

namespace eMAS.Api.TerrenosComodatos.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly IServiceProvider _serviceProvider;
        public GenericRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Tuple<List<KeyValueSelect>, string> GetSingleSelect(string keyparam)
        {
            Tuple<List<KeyValueSelect>, string> data = null;
            string strParamKey = "";
            // Arma Datos de Cabecera
            var paramKeyParameter = new
            {
                key1 = keyparam
            };
            string sMensaje = "";
            List<KeyValueSelect> lsKeyValue = new List<KeyValueSelect>();
            strParamKey = JsonSerializer.Serialize(paramKeyParameter);
            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;
            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                lsKeyValue = db.KeyValueSelects.FromSqlInterpolated(@$"SmcComodato_GetDataDsrGeneric
                                 @Params =  {strParamKey},
                                 @Mensaje = {mensaje} OUTPUT").AsEnumerable().ToList();

                sMensaje = mensaje.Value?.ToString();
            }
            data = new Tuple<List<KeyValueSelect>, string>(lsKeyValue, sMensaje);

            return data;
        }
    }
}
