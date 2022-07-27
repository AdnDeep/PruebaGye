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
    public partial class RepositorioTramiteLectura : IGestionRepositorioLecturaTramites
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositorioTramiteLectura(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Tuple<SmcTramiteEdit, string, short> GetTramitePorId(short id)
        {
            short iContador = 0;
            string sMensaje = string.Empty;
            SmcTramiteEdit _tramiteEdit = new SmcTramiteEdit();
            Tuple<SmcTramiteEdit, string, short> data = null;

            SqlParameter contador = new SqlParameter("p_contador", SqlDbType.SmallInt);
            contador.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                _tramiteEdit = db.SmcTramitesEdit.FromSqlInterpolated(@$"SmcPr_SmcTramites_GetTramitePorId
                                     @Id =  {id},
                                     @Contador = {contador} OUTPUT,
                                     @Mensaje = {mensaje} OUTPUT").AsEnumerable()
                                .FirstOrDefault();

                _tramiteEdit = _tramiteEdit ?? new SmcTramiteEdit();
                
                sMensaje = mensaje.Value?.ToString();
                var sContador = contador.Value?.ToString();
                Int16.TryParse(sContador, out iContador);
            }
            data = new Tuple<SmcTramiteEdit, string, short>(_tramiteEdit, sMensaje, iContador);

            return data;
        }
        public Tuple<List<SmcTramitePaginado>, int> GetTramitesVistaTodosPaginado(TramitesPanelFilterModel panelModel, int numeroPagina, int numeroFilas)
        {
            string strPanelFilterParameter = "";
            var panelFilterParameter = new
            {
                anioexp = panelModel.anioexp,
                secexp = panelModel.secexp,
                sector = panelModel.sector,
                manzana = panelModel.manzana,
                lote = panelModel.lote,
                division = panelModel.division,
                phv = panelModel.phv,
                phh = panelModel.phh,
                numero = panelModel.numero,
                idestado = panelModel.idestado,
                idbeneficiario = panelModel.idbeneficiario
            };
            List<SmcTramitePaginado> lsTramites = new List<SmcTramitePaginado>();
            Tuple<List<SmcTramitePaginado>, int> data = null;
            SqlParameter totalPaginas = new SqlParameter("p_totalPag", SqlDbType.Int);
            totalPaginas.Direction = ParameterDirection.Output;
            int iTotalPaginas = 0;
            strPanelFilterParameter = JsonSerializer.Serialize(panelFilterParameter);

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                lsTramites = db.SmcTramitesPaginado.FromSqlInterpolated(@$"SmcPr_SmcTramites_GetTramitesTodosPaginado
                                     @PanelFilter =  {strPanelFilterParameter},
                                     @NumeroPagina = {numeroPagina},
                                     @NumeroFilas = {numeroFilas},
                                     @TotalPaginas = {totalPaginas} OUTPUT").ToList();

                lsTramites = lsTramites ?? new List<SmcTramitePaginado>();
                var sTotalPaginas = totalPaginas.Value?.ToString();
                Int32.TryParse(sTotalPaginas, out iTotalPaginas);
            }
            data = new Tuple<List<SmcTramitePaginado>, int>(lsTramites, iTotalPaginas);

            return data;
        }
    }
}
