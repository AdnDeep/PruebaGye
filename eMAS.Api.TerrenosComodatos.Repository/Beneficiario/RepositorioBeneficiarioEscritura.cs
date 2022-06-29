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
    public class RepositorioBeneficiarioEscritura : IRepositorioBeneficiarioEscritura
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositorioBeneficiarioEscritura(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Tuple<SmcBeneficiarioEdit, string> Add(SmcBeneficiario beneficiario)
        {
            Tuple<SmcBeneficiarioEdit, string> data = null;
            string strBeneficiarioParam = "";
            string mensajeDB = "";
            var beneficiarioParameter = new
            {
                nombre = beneficiario.Nombre,
                identificacion = beneficiario.Identificacion,
                NombreRepresentante = beneficiario.NombreRepresentante,
                Contacto = beneficiario.Contacto,
                PdpEstado = beneficiario.PdpEstado,

                PdpUsuarioCreacion = beneficiario.PdpUsuarioCreacion,
                PdpFechaCreacion = beneficiario.PdpFechaCreacion,

                PdpUltimaTransaccion = beneficiario.PdpUltimaTransaccion,
                PdpUltimaPcCliente = beneficiario.PdpUltimaPcCliente
            };
            strBeneficiarioParam = JsonSerializer.Serialize(beneficiarioParameter);

            SqlParameter mensaje = new SqlParameter("p_mensaje", SqlDbType.NVarChar, 4000);
            mensaje.Direction = ParameterDirection.Output;

            using (var db = _serviceProvider.GetService<COMODATOContext>()) 
            {
                db.Database.ExecuteSqlInterpolated($@"SmcComodato_SetBeneficarioAdd
                                                    @Beneficiario = {strBeneficiarioParam},
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
            }
            SmcBeneficiarioEdit _beneficiario = new SmcBeneficiarioEdit();
            data = new Tuple<SmcBeneficiarioEdit, string>(_beneficiario, mensajeDB);

            return data;
        }

        public Tuple<SmcBeneficiarioEdit, string> Update(SmcBeneficiario beneficiario)
        {
            Tuple<SmcBeneficiarioEdit, string> data = null;
            string strBeneficiarioParam = "";
            string mensajeDB = "";
            var beneficiarioParameter = new
            {
                Id = beneficiario.IdBeneficiario,
                nombre = beneficiario.Nombre,
                identificacion = beneficiario.Identificacion,
                NombreRepresentante = beneficiario.NombreRepresentante,
                Contacto = beneficiario.Contacto,
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
                db.Database.ExecuteSqlInterpolated($@"SmcComodato_SetBeneficarioUpdate
                                                    @Beneficiario = {strBeneficiarioParam},
                                                    @Mensaje = {mensaje} OUTPUT");

                mensajeDB = mensaje?.Value?.ToString();
            }
            SmcBeneficiarioEdit _beneficiario = new SmcBeneficiarioEdit();
            data = new Tuple<SmcBeneficiarioEdit, string>(_beneficiario, mensajeDB);

            return data;
        }
    }
}
