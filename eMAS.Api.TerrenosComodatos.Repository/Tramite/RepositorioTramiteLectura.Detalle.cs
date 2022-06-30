using eMAS.Api.TerrenosComodatos.Data;
using eMAS.Api.TerrenosComodatos.Entities;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using eMAS.Api.TerrenosComodatos.IRepository;

namespace eMAS.Api.TerrenosComodatos.Repository
{
    public partial class RepositorioTramiteLectura : IGestionRepositorioLecturaTramites
    {
        public Tuple<SmcAnexoTramiteEdit, string, short> GetAnexoPorId(short id)
        {
            short iContador = 0;
            string sMensaje = string.Empty;
            SmcAnexoTramiteEdit _anexoTramiteEdit = new SmcAnexoTramiteEdit();
            Tuple<SmcAnexoTramiteEdit, string, short> data = null;

            SqlParameter contador = new SqlParameter("p_contador", SqlDbType.SmallInt);
            contador.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                _anexoTramiteEdit = db.SmcAnexoTramitesEdit.FromSqlInterpolated(@$"SmcComodato_GetAnexoTramitePorId
                                     @Id =  {id},
                                     @Contador = {contador} OUTPUT,
                                     @Mensaje = {mensaje} OUTPUT").AsEnumerable()
                                .FirstOrDefault();

                _anexoTramiteEdit = _anexoTramiteEdit ?? new SmcAnexoTramiteEdit();

                sMensaje = mensaje.Value?.ToString();
                var sContador = contador.Value?.ToString();
                Int16.TryParse(sContador, out iContador);
            }
            data = new Tuple<SmcAnexoTramiteEdit, string, short>(_anexoTramiteEdit, sMensaje, iContador);

            return data;
        }
        public Tuple<SmcTramitesDescEdit, string, short> GetObservacionPorId(short id)
        {
            short iContador = 0;
            string sMensaje = string.Empty;
            SmcTramitesDescEdit _observacionTramiteEdit = new SmcTramitesDescEdit();
            Tuple<SmcTramitesDescEdit, string, short> data = null;

            SqlParameter contador = new SqlParameter("p_contador", SqlDbType.SmallInt);
            contador.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                _observacionTramiteEdit = db.SmcTramitesDescsEdit.FromSqlInterpolated(@$"SmcComodato_GetObservacionTramitePorId
                                     @Id =  {id},
                                     @Contador = {contador} OUTPUT,
                                     @Mensaje = {mensaje} OUTPUT").AsEnumerable()
                                .FirstOrDefault();
                _observacionTramiteEdit = _observacionTramiteEdit ?? new SmcTramitesDescEdit();
                sMensaje = mensaje.Value?.ToString();
                var sContador = contador.Value?.ToString();
                Int16.TryParse(sContador, out iContador);
            }
            data = new Tuple<SmcTramitesDescEdit, string, short>(_observacionTramiteEdit, sMensaje, iContador);

            return data;
        }
        public Tuple<SmcOficioOtrasDireccioneEdit, string, short> GetSeguimientoOficioPorId(short id)
        {
            short iContador = 0;
            string sMensaje = string.Empty;
            SmcOficioOtrasDireccioneEdit _oficioTramiteEdit = new SmcOficioOtrasDireccioneEdit();
            Tuple<SmcOficioOtrasDireccioneEdit, string, short> data = null;

            SqlParameter contador = new SqlParameter("p_contador", SqlDbType.SmallInt);
            contador.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                _oficioTramiteEdit = db.SmcOficioOtrasDireccionesEdit.FromSqlInterpolated(@$"SmcComodato_GetOficioTramitePorId
                                     @Id =  {id},
                                     @Contador = {contador} OUTPUT,
                                     @Mensaje = {mensaje} OUTPUT").AsEnumerable()
                                .FirstOrDefault();
                _oficioTramiteEdit = _oficioTramiteEdit ?? new SmcOficioOtrasDireccioneEdit();
                sMensaje = mensaje.Value?.ToString();
                var sContador = contador.Value?.ToString();
                Int16.TryParse(sContador, out iContador);
            }
            data = new Tuple<SmcOficioOtrasDireccioneEdit, string, short>(_oficioTramiteEdit, sMensaje, iContador);

            return data;
        }
        public Tuple<SmcTopografiaTerrenoEdit, string, short> GetTopografiaTerrenoPorId(short id)
        {
            short iContador = 0;
            string sMensaje = string.Empty;
            SmcTopografiaTerrenoEdit _topografiaTramiteEdit = new SmcTopografiaTerrenoEdit();
            Tuple<SmcTopografiaTerrenoEdit, string, short> data = null;

            SqlParameter contador = new SqlParameter("p_contador", SqlDbType.SmallInt);
            contador.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.VarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                _topografiaTramiteEdit = db.SmcTopografiaTerrenosEdit.FromSqlInterpolated(@$"SmcComodato_GetTopografiaTramitePorId
                                     @Id =  {id},
                                     @Contador = {contador} OUTPUT,
                                     @Mensaje = {mensaje} OUTPUT").AsEnumerable()
                                .FirstOrDefault();
                _topografiaTramiteEdit = _topografiaTramiteEdit ?? new SmcTopografiaTerrenoEdit();
                sMensaje = mensaje.Value?.ToString();
                var sContador = contador.Value?.ToString();
                Int16.TryParse(sContador, out iContador);
            }
            data = new Tuple<SmcTopografiaTerrenoEdit, string, short>(_topografiaTramiteEdit, sMensaje, iContador);

            return data;
        }
    }
}
