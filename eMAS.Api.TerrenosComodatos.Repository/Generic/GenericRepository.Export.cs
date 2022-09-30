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
    public partial class GenericRepository : IGenericRepository
    {
        public Tuple<List<ExportSingle>, string, string> GetSingleExport(string codigo, string paramsFilter)
        {
            Tuple<List<ExportSingle>, string, string> data = null;

            
            string strRespuestaColumnas = "";
            string strRespuestaNombreArchivo = "";
            List<ExportSingle> lsResult = new List<ExportSingle>();

            SqlParameter sqlRespuestaColumnas = new SqlParameter("p_RespuestaColumnas", SqlDbType.VarChar, 4000);
            sqlRespuestaColumnas.Direction = ParameterDirection.Output;

            SqlParameter sqlRespuestaNombreArchivo = new SqlParameter("p_RespuestaNombreArchivo", SqlDbType.VarChar, 80);
            sqlRespuestaNombreArchivo.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                lsResult = db.ExportsSingle.FromSqlInterpolated(@$"SmcPr_SmcExportacion_GetDataGeneric
                                 @Codigo = {codigo},
                                 @Params =  {paramsFilter},
                                 @ResultadoColumnas = {sqlRespuestaColumnas} OUTPUT,
                                 @NombreArchivo = {sqlRespuestaNombreArchivo} OUTPUT").AsEnumerable().ToList();

                strRespuestaColumnas = sqlRespuestaColumnas.Value?.ToString();
                strRespuestaNombreArchivo = sqlRespuestaNombreArchivo.Value?.ToString();
            }
            data = new Tuple<List<ExportSingle>, string, string>(lsResult, strRespuestaColumnas, strRespuestaNombreArchivo);

            return data;
        }
    }
}
