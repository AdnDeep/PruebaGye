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
        private readonly IServiceProvider _serviceProvider;
        public RepositorioTramiteEscritura(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Tuple<short, string> Agregar(SmcTramite tramite)
        {
            Tuple<short, string> data = null;
            string strTramiteParam = "";
            string mensajeDB = "";
            var tramiteParameter = new
            {
                Anio = tramite.Anio,
                Secuencia = tramite.Secuencia,
                IdSector = tramite.IdSector,
                Manzana = tramite.Manzana,
                Lote = tramite.Lote,
                Division = tramite.Division,
                Phv = tramite.Phv,
                Phh = tramite.Phh,
                Numero = tramite.Numero,
                IdBeneficiario = tramite.IdBeneficiario,
                IdTipoContrato = tramite.IdTipoContrato,
                AreaSolar = tramite.AreaSolar,
                AniosPlazo = tramite.AniosPlazo,
                IdEstado = tramite.IdEstado,
                IdDireccion = tramite.IdDireccion,
                AprobacionConcejoMun = tramite.AprobacionConcejoMun,
                FechaAprobConcejoMun = tramite.FechaAprobConcejoMun,
                FechaEscritura = tramite.FechaEscritura,
                FechaInsRegProp = tramite.FechaInsRegProp,
                OficioRevocatoriaMod = tramite.OficioRevocatoriaMod,
                FechaInsRevocatoria = tramite.FechaInsRevocatoria,
                ObservacionJuridico = tramite.ObservacionJuridico,
                BaseOrigen = tramite.BaseOrigen,
                OficioAg = tramite.OficioAg,
                OficioDase = tramite.OficioDase,
                PdpEstado = tramite.PdpEstado,

                PdpUsuarioCreacion = tramite.PdpUsuarioCreacion,
                PdpFechaCreacion = tramite.PdpFechaCreacion,

                PdpUltimaTransaccion = tramite.PdpUltimaTransaccion,
                PdpUltimaPcCliente = tramite.PdpUltimaPcCliente
            };
            strTramiteParam = JsonSerializer.Serialize(tramiteParameter);
            short iIdInserted = 0;
            SqlParameter idinserted = new SqlParameter("p_idinserted", SqlDbType.SmallInt);
            idinserted.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                db.Database.ExecuteSqlInterpolated($@"SmcPr_SmcTramites_SetTramiteAdd
                                                    @Tramite = {strTramiteParam},
                                                    @IdInserted = {idinserted} OUTPUT,
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
                var _idinserted = idinserted.Value?.ToString();
                Int16.TryParse(_idinserted, out iIdInserted);
            }

            data = new Tuple<short, string>(iIdInserted, mensajeDB);

            return data;
        }
        public Tuple<short, string> Actualizar(SmcTramite tramite)
        {
            Tuple<short, string> data = null;
            string strTramiteParam = "";
            string mensajeDB = "";
            var tramiteParameter = new
            {
                Id = tramite.IdTramite,
                Anio = tramite.Anio,
                Secuencia = tramite.Secuencia,
                IdSector = tramite.IdSector,
                Manzana = tramite.Manzana,
                Lote = tramite.Lote,
                Division = tramite.Division,
                Phv = tramite.Phv,
                Phh = tramite.Phh,
                Numero = tramite.Numero,
                IdBeneficiario = tramite.IdBeneficiario,
                IdTipoContrato = tramite.IdTipoContrato,
                AreaSolar = tramite.AreaSolar,
                AniosPlazo = tramite.AniosPlazo,
                IdEstado = tramite.IdEstado,
                IdDireccion = tramite.IdDireccion,
                AprobacionConcejoMun = tramite.AprobacionConcejoMun,
                FechaAprobConcejoMun = tramite.FechaAprobConcejoMun,
                FechaEscritura = tramite.FechaEscritura,
                FechaInsRegProp = tramite.FechaInsRegProp,
                OficioRevocatoriaMod = tramite.OficioRevocatoriaMod,
                FechaInsRevocatoria = tramite.FechaInsRevocatoria,
                ObservacionJuridico = tramite.ObservacionJuridico,
                BaseOrigen = tramite.BaseOrigen,
                OficioAg = tramite.OficioAg,
                OficioDase = tramite.OficioDase,

                PdpEstado = tramite.PdpEstado,
                PdpUsuarioUltimaModificacion = tramite.PdpUsuarioUltimaModificacion,
                PdpFechaUltimaModificacion = tramite.PdpFechaUltimaModificacion,
                PdpUltimaTransaccion = tramite.PdpUltimaTransaccion,
                PdpUltimaPcCliente = tramite.PdpUltimaPcCliente
            };
            strTramiteParam = JsonSerializer.Serialize(tramiteParameter);
            short contador = 0;
            SqlParameter paramContador = new SqlParameter("p_contador", SqlDbType.SmallInt);
            paramContador.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                db.Database.ExecuteSqlInterpolated($@"SmcPr_SmcTramites_SetTramiteUpdate
                                                    @Tramite = {strTramiteParam},
                                                    @Contador = {paramContador} OUTPUT,
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
                var _contador = paramContador.Value?.ToString();
                Int16.TryParse(_contador, out contador);
            }

            data = new Tuple<short, string>(contador, mensajeDB);

            return data;
        }
    }
}
