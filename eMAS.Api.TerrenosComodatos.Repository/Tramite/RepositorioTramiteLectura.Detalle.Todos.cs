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
        public Tuple<List<SmcAnexoTramiteEdit>, string> GetAnexosPorIdTramite(short idTramite)
        {
            string sMensaje = string.Empty;
            string strAnexoTramiteFilter = string.Empty;
            List<SmcAnexoTramiteEdit> lsAnexosTramite = new List<SmcAnexoTramiteEdit>();
            Tuple<List<SmcAnexoTramiteEdit>, string> data = null;

            var anexoTramiteFilter = new
            {
                IdTramite = idTramite
            };

            strAnexoTramiteFilter = JsonSerializer.Serialize(anexoTramiteFilter);

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                lsAnexosTramite = db.SmcAnexoTramitesEdit.FromSqlInterpolated(@$"SmcPr_SmcAnexoTramite_GetAnexoTramiteAll
                                     @AnexoTramite =  {strAnexoTramiteFilter},
                                     @Mensaje = {mensaje} OUTPUT").ToList();

                lsAnexosTramite = lsAnexosTramite ?? new List<SmcAnexoTramiteEdit>();
                sMensaje = mensaje.Value?.ToString();
            }
            data = new Tuple<List<SmcAnexoTramiteEdit>, string>(lsAnexosTramite, sMensaje);

            return data;
        }
        public Tuple<List<SmcTramitesDescEdit>, string> GetObservacionsPorIdTramite(short idTramite)
        {
            string sMensaje = string.Empty;
            string strObservacionTramiteFilter = string.Empty;
            List<SmcTramitesDescEdit> lsObservacionsTramite = new List<SmcTramitesDescEdit>();
            Tuple<List<SmcTramitesDescEdit>, string> data = null;

            var observacionTramiteFilter = new
            {
                IdTramite = idTramite
            };

            strObservacionTramiteFilter = JsonSerializer.Serialize(observacionTramiteFilter);

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                lsObservacionsTramite = db.SmcTramitesDescsEdit.FromSqlInterpolated(@$"SmcPr_SmcTramites_GetObservacionTramiteAll
                                     @ObservacionTramite =  {strObservacionTramiteFilter},
                                     @Mensaje = {mensaje} OUTPUT").ToList();
                lsObservacionsTramite = lsObservacionsTramite ?? new List<SmcTramitesDescEdit>();
                sMensaje = mensaje.Value?.ToString();
            }
            data = new Tuple<List<SmcTramitesDescEdit>, string>(lsObservacionsTramite, sMensaje);

            return data;
        }
        public Tuple<List<SmcOficioOtrasDireccioneEdit>, string> GetSeguimientoOficioPorIdTramite(short idTramite)
        {
            string sMensaje = string.Empty;
            string strOficioTramiteFilter = string.Empty;
            List<SmcOficioOtrasDireccioneEdit> lsOficioTramite = new List<SmcOficioOtrasDireccioneEdit>();
            Tuple<List<SmcOficioOtrasDireccioneEdit>, string> data = null;

            var oficioTramiteFilter = new
            {
                IdTramite = idTramite
            };

            strOficioTramiteFilter = JsonSerializer.Serialize(oficioTramiteFilter);

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                lsOficioTramite = db.SmcOficioOtrasDireccionesEdit.FromSqlInterpolated(@$"SmcPr_SmcOficioOtrasDirecciones_GetOficioTramiteAll
                                     @OficioTramite =  {strOficioTramiteFilter},
                                     @Mensaje = {mensaje} OUTPUT").ToList();
                lsOficioTramite = lsOficioTramite ?? new List<SmcOficioOtrasDireccioneEdit>();
                sMensaje = mensaje.Value?.ToString();
            }
            data = new Tuple<List<SmcOficioOtrasDireccioneEdit>, string>(lsOficioTramite, sMensaje);

            return data;
        }
        public Tuple<List<SmcTopografiaTerrenoEdit>, string> GetTopografiaTerrenoPorIdTramite(short idTramite)
        {
            string sMensaje = string.Empty;
            string strTopografiaTramiteFilter = string.Empty;
            List<SmcTopografiaTerrenoEdit> lsTopografiaTramite = new List<SmcTopografiaTerrenoEdit>();
            Tuple<List<SmcTopografiaTerrenoEdit>, string> data = null;

            var topografiaTramiteFilter = new
            {
                IdTramite = idTramite
            };

            strTopografiaTramiteFilter = JsonSerializer.Serialize(topografiaTramiteFilter);

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                lsTopografiaTramite = db.SmcTopografiaTerrenosEdit.FromSqlInterpolated(@$"SmcPr_SmcTopografiaTerreno_GetTopografiaTramiteAll
                                     @TopografiaTramite =  {strTopografiaTramiteFilter},
                                     @Mensaje = {mensaje} OUTPUT").ToList();
                lsTopografiaTramite = lsTopografiaTramite ?? new List<SmcTopografiaTerrenoEdit>();
                sMensaje = mensaje.Value?.ToString();
            }
            data = new Tuple<List<SmcTopografiaTerrenoEdit>, string>(lsTopografiaTramite, sMensaje);

            return data;
        }
    }
}
