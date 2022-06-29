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
    public class GestionRepositorioLecturaGenerica : IGestionRepositorioLecturaGenerica
    {
        private string _cadenaConexion;
        private readonly IConfiguration _configuration;
        public GestionRepositorioLecturaGenerica(IConfiguration configuration)
        {
            _configuration = configuration;
            _cadenaConexion = _configuration["ConnectionStrings:ComodatoDatabaseLectura"];
        }
        public ResultadoDTO<Tuple<List<KeyValueSelect>, string>> ObtenerListadoGenerico(string keyparam)
        {
            string mensajeBD = string.Empty;
            KeyValueSelect item = null;
            List<KeyValueSelect> lsItems = new List<KeyValueSelect>();
            Tuple<List<KeyValueSelect>, string> data = null;
            ResultadoDTO<Tuple<List<KeyValueSelect>, string>> respuesta = new ResultadoDTO<Tuple<List<KeyValueSelect>, string>>();
            List<Mensaje> mensajes = new List<Mensaje>();
            string strParamKey = "";
            // Arma Datos de Cabecera
            var paramKeyParameter = new
            {
                key1 = keyparam
            };
            strParamKey = JsonSerializer.Serialize(paramKeyParameter);

            using (SqlConnection cn = new SqlConnection(_cadenaConexion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("SmcComodato_GetDataDsrGeneric", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Seteo de Parametros 
                    var paramIdParameter = new SqlParameter("@Params", strParamKey)
                    {
                        Direction = ParameterDirection.Input
                    };
                    cmd.Parameters.Add(paramIdParameter);

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
                                    item = new KeyValueSelect();
                                    item.key = Convert.ToString(drlector["key"]);
                                    item.value = Convert.ToString(drlector["valor"]);
                                    lsItems.Add(item);
                                }
                            }
                            if (drlector != null)
                            {
                                drlector.Close();
                            }
                        }

                        mensajeBD = outParamMensaje.Value?.ToString();

                        data = new Tuple<List<KeyValueSelect>, string>(lsItems, mensajeBD);
                    }
                    catch (Exception ex)
                    {
                        mensajes.Add(new Mensaje { codigo = "GRGIMPLGEN001", descripcion = $"{ex.Message}" });
                        data = new Tuple<List<KeyValueSelect>, string>(new List<KeyValueSelect>(), string.Empty);
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
