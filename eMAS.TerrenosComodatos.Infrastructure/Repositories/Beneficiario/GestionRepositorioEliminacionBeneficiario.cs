using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Entities;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace eMAS.TerrenosComodatos.Infrastructure.Repositories
{
    public class GestionRepositorioEliminacionBeneficiario : IGestionRepositorioEliminacionBeneficiario
    {
        private string _cadenaConexion;
        private readonly IConfiguration _configuration;
        public GestionRepositorioEliminacionBeneficiario(IConfiguration configuration)
        {
            _configuration = configuration;
            _cadenaConexion = _configuration["ConnectionStrings:ComodatoDatabaseEscritura"];
        }

        public ResultadoDTO<string> EliminarBeneficiario(Beneficiario model)
        {
            string mensajeBD = string.Empty;
            ResultadoDTO<string> respuesta = new ResultadoDTO<string>();
            List<Mensaje> mensajes = new List<Mensaje>();

            var beneficiarioParameter = new
            {
                Id = model.IdBeneficiario,
                PdpEstado = model.PdpEstado,
                PdpUsuarioUltimaModificacion = model.PdpUsuarioUltimaModificacion,
                PdpFechaUltimaModificacion = model.PdpFechaUltimaModificacion,
                PdpUltimaTransaccion = model.PdpUltimaTransaccion,
                PdpUltimaPcCliente = model.PdpUltimaPcCliente
            };

            string strBeneficiarioParameter = JsonSerializer.Serialize(beneficiarioParameter);

            using (SqlConnection cn = new SqlConnection(_cadenaConexion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("SmcComodato_SetBeneficarioDelete", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Seteo de Parametros 
                    var paramBeneficioFilterParameter = new SqlParameter("@Beneficiario", strBeneficiarioParameter)
                    {
                        Direction = ParameterDirection.Input
                    };
                    cmd.Parameters.Add(paramBeneficioFilterParameter);

                    var outParamMensaje = new SqlParameter("@Mensaje", SqlDbType.NVarChar, 4000)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outParamMensaje);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        mensajeBD = outParamMensaje.Value?.ToString();

                    }
                    catch (Exception ex)
                    {
                        mensajes.Add(new Mensaje { codigo = "GRBIMPLELMINT001", descripcion = $"{ex.Message}" });
                        mensajeBD = "";
                    }
                }
                cn.Close();
            }

            respuesta.dataresult = mensajeBD;
            respuesta.mensajes = mensajes;

            return respuesta;
        }
    }
}
