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
    public class GestionRepositorioValidacionesBeneficiario : IGestionRepositorioValidacionesBeneficiario
    {
        private string _cadenaConexion;
        private readonly IConfiguration _configuration;
        public GestionRepositorioValidacionesBeneficiario(IConfiguration configuration)
        {
            _configuration = configuration;
            _cadenaConexion = _configuration["ConnectionStrings:ComodatoDatabaseLectura"];
        }
        public ResultadoDTO<Tuple<List<EntidadValidacion>, string>> GetDataValidacionBeneficiarios1(BeneficiariosValidacion1Filter validacionFilter)
        {
            string mensajeBD = string.Empty;
            EntidadValidacion entidadValidacion = null;
            List<EntidadValidacion> lsEntidadValidacion = new List<EntidadValidacion>();
            Tuple<List<EntidadValidacion>, string> data = null;
            ResultadoDTO<Tuple<List<EntidadValidacion>, string>> respuesta = new ResultadoDTO<Tuple<List<EntidadValidacion>, string>>();
            List<Mensaje> mensajes = new List<Mensaje>();

            var panelFilterParameter = new
            {
                Id = validacionFilter.Id,
                nombre = validacionFilter.nombre
            };
            string strBenficiarioFilterParameter = JsonSerializer.Serialize(panelFilterParameter);

            using (SqlConnection cn = new SqlConnection(_cadenaConexion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("SmcPr_SmcBeneficiario_GetDataValidationBeneficiarios1", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Seteo de Parametros 
                    var paramBeneficioFilterParameter = new SqlParameter("@BeneficiarioFilter", strBenficiarioFilterParameter)
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
                        using (SqlDataReader drlector = cmd.ExecuteReader())
                        {
                            if (drlector != null && drlector.HasRows)
                            {
                                while (drlector.Read())
                                {
                                    entidadValidacion = new EntidadValidacion();
                                    entidadValidacion.clave = Convert.ToString(drlector["CLAVE"]);
                                    entidadValidacion.valorNumerico = Convert.ToInt16(drlector["VALORNUMERICO"]);
                                    lsEntidadValidacion.Add(entidadValidacion);
                                }
                            }
                            if (drlector != null)
                            {
                                drlector.Close();
                            }
                        }

                        mensajeBD = outParamMensaje.Value?.ToString();

                        data = new Tuple<List<EntidadValidacion>, string>(lsEntidadValidacion, mensajeBD);
                    }
                    catch (Exception ex)
                    {
                        mensajes.Add(new Mensaje { codigo = "GRBIMPLVALINT001", descripcion = $"{ex.Message}" });
                        data = new Tuple<List<EntidadValidacion>, string>(new List<EntidadValidacion>(), string.Empty);
                    }
                }
                cn.Close();
            }

            respuesta.dataresult = data;
            respuesta.mensajes = mensajes;

            return respuesta;
        }
    }
}
