using eMAS.Api.TerrenosComodatos.Data;
using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IRepository;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace eMAS.Api.TerrenosComodatos.Repository
{
    public class RepositorioBeneficiarioEliminacion : IRepositorioBeneficiarioEliminacion
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositorioBeneficiarioEliminacion(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public string Delete(SmcBeneficiario beneficiario)
        {
            string strBeneficiarioParam = "";
            string mensajeDB = "";
            var beneficiarioParameter = new
            {
                Id = beneficiario.IdBeneficiario,
                PdpEstado = beneficiario.PdpEstado,
                PdpUsuarioUltimaModificacion = beneficiario.PdpUsuarioUltimaModificacion,
                PdpFechaUltimaModificacion = beneficiario.PdpFechaUltimaModificacion,
                PdpUltimaTransaccion = beneficiario.PdpUltimaTransaccion,
                PdpUltimaPcCliente = beneficiario.PdpUltimaPcCliente
            };
            strBeneficiarioParam = JsonSerializer.Serialize(beneficiarioParameter);

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>())
            {
                db.Database.ExecuteSqlInterpolated($@"SmcPr_SmcBeneficiario_SetBeneficarioDelete
                                                    @Beneficiario = {strBeneficiarioParam},
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
            }
            return mensajeDB;
        }
    }
}
