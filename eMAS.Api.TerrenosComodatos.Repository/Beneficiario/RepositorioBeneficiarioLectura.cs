using eMAS.Api.TerrenosComodatos.Data;
using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using System.Data;
using eMAS.Api.TerrenosComodatos.IRepository;

namespace eMAS.Api.TerrenosComodatos.Repository
{
    public class RepositorioBeneficiarioLectura : IRepositorioBeneficiarioLectura
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositorioBeneficiarioLectura(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public  Tuple<SmcBeneficiarioEdit, string, short> GetBeneficiarioPorId(short id)
        {
            short iContador = 0;
            string sMensaje = string.Empty;
            SmcBeneficiarioEdit _beneficiarioEdit = new SmcBeneficiarioEdit();
            Tuple<SmcBeneficiarioEdit, string, short> data = null;

            SqlParameter contador = new SqlParameter("p_contador", SqlDbType.SmallInt);
            contador.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje",SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                _beneficiarioEdit = db.SmcBeneficiariosEdit.FromSqlInterpolated(@$"SmcPr_SmcBeneficiario_GetBeneficarioPorId
                                 @Id =  {id},
                                 @Contador = {contador} OUTPUT,
                                 @Mensaje = {mensaje} OUTPUT").AsEnumerable()
                                .FirstOrDefault();

                sMensaje = mensaje.Value?.ToString();
                var sContador = contador.Value?.ToString();
                Int16.TryParse(sContador, out iContador);
            }
            data = new Tuple<SmcBeneficiarioEdit, string, short>(_beneficiarioEdit, sMensaje, iContador);

            return data;
        }

        public async Task<Tuple<List<SmcBeneficiarioPaginado>, int>> GetBeneficiarioTodosPaginado(BeneficiariosPanelFilterModel panelModel, int numeroPagina, int numeroFilas)
        {
            string strPanelFilterParameter = "";
            var panelFilterParameter = new
            {
                nombre = panelModel.nombre,
                representante = panelModel.representante,
                ruc = panelModel.ruc,
                contacto = panelModel.contacto
            };
            List<SmcBeneficiarioPaginado> lsBeneficiario = new List<SmcBeneficiarioPaginado>();
            Tuple<List<SmcBeneficiarioPaginado>, int> data = null;
            SqlParameter totalPaginas = new SqlParameter("p_totalPag", SqlDbType.Int);
            totalPaginas.Direction = ParameterDirection.Output;
            int iTotalPaginas = 0;
            strPanelFilterParameter = JsonSerializer.Serialize(panelFilterParameter);

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                lsBeneficiario = await db.SmcBeneficiariosPaginado.FromSqlInterpolated(@$"SmcPr_SmcBeneficiario_GetBeneficariosTodosPaginado
                                 @PanelFilter =  {strPanelFilterParameter},
                                 @NumeroPagina = {numeroPagina},
                                 @NumeroFilas = {numeroFilas},
                                 @TotalPaginas = {totalPaginas} OUTPUT").ToListAsync();

                var sTotalPaginas = totalPaginas.Value?.ToString();
                Int32.TryParse(sTotalPaginas, out iTotalPaginas);
            }
            data = new Tuple<List<SmcBeneficiarioPaginado>, int>(lsBeneficiario, iTotalPaginas);

            return data;
        }
    }
}
