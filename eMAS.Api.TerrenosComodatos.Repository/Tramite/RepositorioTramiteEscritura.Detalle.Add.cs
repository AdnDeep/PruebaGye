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
        public Tuple<short, string> AgregarAnexo(SmcAnexoTramite anexoTramite)
        {
            Tuple<short, string> data = null;
            string strAnexoTramiteParam = "";
            string mensajeDB = "";
            
            var anexoTramiteParameter = new
            {
                IdTramite = anexoTramite.IdTramite,
                Link = anexoTramite.Link,
                
                PdpEstado = anexoTramite.PdpEstado,

                PdpUsuarioCreacion = anexoTramite.PdpUsuarioCreacion,
                PdpFechaCreacion = anexoTramite.PdpFechaCreacion,

                PdpUltimaTransaccion = anexoTramite.PdpUltimaTransaccion,
                PdpUltimaPcCliente = anexoTramite.PdpUltimaPcCliente
            };
            strAnexoTramiteParam = JsonSerializer.Serialize(anexoTramiteParameter);
            short iIdInserted = 0;
            SqlParameter idinserted = new SqlParameter("p_idinserted", SqlDbType.SmallInt);
            idinserted.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                db.Database.ExecuteSqlInterpolated($@"SmcPr_SmcAnexoTramite_SetAnexoTramiteAdd
                                                    @AnexoTramite = {strAnexoTramiteParam},
                                                    @IdInserted = {idinserted} OUTPUT,
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
                var _idinserted = idinserted.Value?.ToString();
                Int16.TryParse(_idinserted, out iIdInserted);
            }

            data = new Tuple<short, string>(iIdInserted, mensajeDB);

            return data;
        }

        public Tuple<short, string> AgregarObservacion(SmcTramitesDesc observacionTramite)
        {
            Tuple<short, string> data = null;
            string strObservacionTramiteParam = "";
            string mensajeDB = "";
            
            var observacionTramiteParameter = new
            {
                IdTramite = observacionTramite.IdTramite,
                Fecha = observacionTramite.Fecha,
                Observacion = observacionTramite.Observacion,
                PdpEstado = observacionTramite.PdpEstado,

                PdpUsuarioCreacion = observacionTramite.PdpUsuarioCreacion,
                PdpFechaCreacion = observacionTramite.PdpFechaCreacion,

                PdpUltimaTransaccion = observacionTramite.PdpUltimaTransaccion,
                PdpUltimaPcCliente = observacionTramite.PdpUltimaPcCliente
            };
            strObservacionTramiteParam = JsonSerializer.Serialize(observacionTramiteParameter);
            short iIdInserted = 0;
            SqlParameter idinserted = new SqlParameter("p_idinserted", SqlDbType.SmallInt);
            idinserted.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                db.Database.ExecuteSqlInterpolated($@"SmcPr_SmcTramitesDescs_SetObservacionTramiteAdd
                                                    @ObservacionTramite = {strObservacionTramiteParam},
                                                    @IdInserted = {idinserted} OUTPUT,
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
                var _idinserted = idinserted.Value?.ToString();
                Int16.TryParse(_idinserted, out iIdInserted);
            }

            data = new Tuple<short, string>(iIdInserted, mensajeDB);

            return data;
        }

        public Tuple<short, string> AgregarSeguimientoOficio(SmcOficioOtrasDireccione oficioTramite)
        {
            Tuple<short, string> data = null;
            string strOficioTramiteParam = "";
            string mensajeDB = "";
            
            var oficioTramiteParameter = new
            {
                IdTramite = oficioTramite.IdTramite,
                IdDireccion = oficioTramite.IdDireccion,
                Oficio = oficioTramite.Oficio,
                FechaEnvio = oficioTramite.FechaEnvio,
                OficioRespuesta = oficioTramite.OficioRespuesta,
                FechaRespuesta = oficioTramite.FechaRespuesta,

                PdpEstado = oficioTramite.PdpEstado,

                PdpUsuarioCreacion = oficioTramite.PdpUsuarioCreacion,
                PdpFechaCreacion = oficioTramite.PdpFechaCreacion,

                PdpUltimaTransaccion = oficioTramite.PdpUltimaTransaccion,
                PdpUltimaPcCliente = oficioTramite.PdpUltimaPcCliente
            };
            strOficioTramiteParam = JsonSerializer.Serialize(oficioTramiteParameter);
            short iIdInserted = 0;
            SqlParameter idinserted = new SqlParameter("p_idinserted", SqlDbType.SmallInt);
            idinserted.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                db.Database.ExecuteSqlInterpolated($@"SmcPr_SmcOficioOtrasDirecciones_SetOficioTramiteAdd
                                                    @OficioTramite = {strOficioTramiteParam},
                                                    @IdInserted = {idinserted} OUTPUT,
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
                var _idinserted = idinserted.Value?.ToString();
                Int16.TryParse(_idinserted, out iIdInserted);
            }

            data = new Tuple<short, string>(iIdInserted, mensajeDB);

            return data;
        }

        public Tuple<short, string> AgregarTopografiaTerreno(SmcTopografiaTerreno topografiaTramite)
        {
            Tuple<short, string> data = null;
            string strTopografiaTramiteParam = "";
            string mensajeDB = "";
            
            var topografiaTramiteParameter = new
            {
                IdTipoTopografiaTerreno = topografiaTramite.IdTipoTopografiaTerreno,
                IdTramite = topografiaTramite.IdTramite,

                Oficio = topografiaTramite.Oficio,
                FechaEnvio = topografiaTramite.FechaEnvio,
                OficioRespuesta = topografiaTramite.OficioRespuesta,
                FechaRespuesta = topografiaTramite.FechaRespuesta,

                PdpEstado = topografiaTramite.PdpEstado,

                PdpUsuarioCreacion = topografiaTramite.PdpUsuarioCreacion,
                PdpFechaCreacion = topografiaTramite.PdpFechaCreacion,

                PdpUltimaTransaccion = topografiaTramite.PdpUltimaTransaccion,
                PdpUltimaPcCliente = topografiaTramite.PdpUltimaPcCliente
            };
            strTopografiaTramiteParam = JsonSerializer.Serialize(topografiaTramiteParameter);
            short iIdInserted = 0;
            SqlParameter idinserted = new SqlParameter("p_idinserted", SqlDbType.SmallInt);
            idinserted.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                db.Database.ExecuteSqlInterpolated($@"SmcPr_SmcTopografiaTerreno_SetTopografiaTramiteAdd
                                                    @TopografiaTramite = {strTopografiaTramiteParam},
                                                    @IdInserted = {idinserted} OUTPUT,
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
                var _idinserted = idinserted.Value?.ToString();
                Int16.TryParse(_idinserted, out iIdInserted);
            }

            data = new Tuple<short, string>(iIdInserted, mensajeDB);

            return data;
        }
    }
}
