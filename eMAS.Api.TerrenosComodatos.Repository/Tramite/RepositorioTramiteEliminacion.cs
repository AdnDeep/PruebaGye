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
    public partial class RepositorioTramiteEliminacion : IGestionRepositorioEliminacionTramites
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositorioTramiteEliminacion(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Tuple<short, string> Eliminar(SmcTramite tramite)
        {
            Tuple<short, string> data = null;
            string strTramiteParam = "";
            string mensajeDB = "";
            var tramiteParameter = new
            {
                Id = tramite.IdTramite,
                PdpEstado = tramite.PdpEstado,
                PdpUsuarioUltimaModificacion = tramite.PdpUsuarioUltimaModificacion,
                PdpFechaUltimaModificacion = tramite.PdpFechaUltimaModificacion,
                PdpUltimaTransaccion = tramite.PdpUltimaTransaccion,
                PdpUltimaPcCliente = tramite.PdpUltimaPcCliente
            };
            strTramiteParam = JsonSerializer.Serialize(tramiteParameter);
            
            short icontador = 0;
            SqlParameter paramContador = new SqlParameter("p_contador", SqlDbType.SmallInt);
            paramContador.Direction = ParameterDirection.Output;

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                db.Database.ExecuteSqlInterpolated($@"SmcPr_SmcTramites_SetTramiteDelete
                                                    @Tramite = {strTramiteParam},
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
