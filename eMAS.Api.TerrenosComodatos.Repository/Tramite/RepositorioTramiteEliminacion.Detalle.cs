﻿using eMAS.Api.TerrenosComodatos.Data;
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
    public partial class RepositorioTramiteEliminacion : IGestionRepositorioEliminacionTramites
    {
        public Tuple<short, string> EliminarAnexo(SmcAnexoTramite anexoTramite)
        {
            Tuple<short, string> data = null;
            string strAnexoTramiteParam = "";
            string mensajeDB = "";
            var anexoTramiteParameter = new
            {
                IdAnexoTramite = anexoTramite.IdAnexoTramite,
                PdpEstado = anexoTramite.PdpEstado,
                PdpUsuarioUltimaModificacion = anexoTramite.PdpUsuarioUltimaModificacion,
                PdpFechaUltimaModificacion = anexoTramite.PdpFechaUltimaModificacion,
                PdpUltimaTransaccion = anexoTramite.PdpUltimaTransaccion,
                PdpUltimaPcCliente = anexoTramite.PdpUltimaPcCliente
            };
            strAnexoTramiteParam = JsonSerializer.Serialize(anexoTramiteParameter);

            short icontador = 0;
            SqlParameter paramContador = new SqlParameter("p_contador", SqlDbType.SmallInt);
            paramContador.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                db.Database.ExecuteSqlInterpolated($@"SmcPr_SmcAnexoTramite_SetAnexoTramiteDelete
                                                    @AnexoTramite = {strAnexoTramiteParam},
                                                    @Contador = {paramContador} OUTPUT,
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
                var _contador = paramContador.Value?.ToString();
                Int16.TryParse(_contador, out icontador);
            }
            data = new Tuple<short, string>(icontador, mensajeDB);

            return data;
        }

        public Tuple<short, string> EliminarObservacion(SmcTramitesDesc observacionTramite)
        {
            Tuple<short, string> data = null;
            string strObservacionTramiteParam = "";
            string mensajeDB = "";
            var observacionTramiteParameter = new
            {
                IdObservacionTramite = observacionTramite.IdTramiteDesc,
                PdpEstado = observacionTramite.PdpEstado,
                PdpUsuarioUltimaModificacion = observacionTramite.PdpUsuarioUltimaModificacion,
                PdpFechaUltimaModificacion = observacionTramite.PdpFechaUltimaModificacion,
                PdpUltimaTransaccion = observacionTramite.PdpUltimaTransaccion,
                PdpUltimaPcCliente = observacionTramite.PdpUltimaPcCliente
            };
            strObservacionTramiteParam = JsonSerializer.Serialize(observacionTramiteParameter);

            short icontador = 0;
            SqlParameter paramContador = new SqlParameter("p_contador", SqlDbType.SmallInt);
            paramContador.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                db.Database.ExecuteSqlInterpolated($@"SmcPr_SmcTramitesDescs_SetObservacionTramiteDelete
                                                    @ObservacionTramite = {strObservacionTramiteParam},
                                                    @Contador = {paramContador} OUTPUT,
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
                var _contador = paramContador.Value?.ToString();
                Int16.TryParse(_contador, out icontador);
            }
            data = new Tuple<short, string>(icontador, mensajeDB);

            return data;
        }

        public Tuple<short, string> EliminarSeguimientoOficio(SmcOficioOtrasDireccione oficioTramite)
        {
            Tuple<short, string> data = null;
            string strOficioTramiteParam = "";
            string mensajeDB = "";
            var oficioTramiteParameter = new
            {
                IdOficioOtrasDirecciones = oficioTramite.IdOficioOtrasDirecciones,
                PdpEstado = oficioTramite.PdpEstado,
                PdpUsuarioUltimaModificacion = oficioTramite.PdpUsuarioUltimaModificacion,
                PdpFechaUltimaModificacion = oficioTramite.PdpFechaUltimaModificacion,
                PdpUltimaTransaccion = oficioTramite.PdpUltimaTransaccion,
                PdpUltimaPcCliente = oficioTramite.PdpUltimaPcCliente
            };
            strOficioTramiteParam = JsonSerializer.Serialize(oficioTramiteParameter);

            short icontador = 0;
            SqlParameter paramContador = new SqlParameter("p_contador", SqlDbType.SmallInt);
            paramContador.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                db.Database.ExecuteSqlInterpolated($@"SmcPr_SmcOficioOtrasDirecciones_SetOficioTramiteDelete
                                                    @OficioTramite = {strOficioTramiteParam},
                                                    @Contador = {paramContador} OUTPUT,
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
                var _contador = paramContador.Value?.ToString();
                Int16.TryParse(_contador, out icontador);
            }
            data = new Tuple<short, string>(icontador, mensajeDB);

            return data;
        }

        public Tuple<short, string> EliminarTopografiaTerreno(SmcTopografiaTerreno topografiaTramite)
        {
            Tuple<short, string> data = null;
            string strTopografiaTramiteParam = "";
            string mensajeDB = "";
            var topografiaTramiteParameter = new
            {
                IdTopografiaTerreno = topografiaTramite.IdTopografiaTerreno,
                PdpEstado = topografiaTramite.PdpEstado,
                PdpUsuarioUltimaModificacion = topografiaTramite.PdpUsuarioUltimaModificacion,
                PdpFechaUltimaModificacion = topografiaTramite.PdpFechaUltimaModificacion,
                PdpUltimaTransaccion = topografiaTramite.PdpUltimaTransaccion,
                PdpUltimaPcCliente = topografiaTramite.PdpUltimaPcCliente
            };
            strTopografiaTramiteParam = JsonSerializer.Serialize(topografiaTramiteParameter);

            short icontador = 0;
            SqlParameter paramContador = new SqlParameter("p_contador", SqlDbType.SmallInt);
            paramContador.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                db.Database.ExecuteSqlInterpolated($@"SmcPr_SmcTopografiaTerreno_SetTopografiaTramiteDelete
                                                    @TopografiaTramite = {strTopografiaTramiteParam},
                                                    @Contador = {paramContador} OUTPUT,
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
                var _contador = paramContador.Value?.ToString();
                Int16.TryParse(_contador, out icontador);
            }
            data = new Tuple<short, string>(icontador, mensajeDB);

            return data;
        }
    }
}
