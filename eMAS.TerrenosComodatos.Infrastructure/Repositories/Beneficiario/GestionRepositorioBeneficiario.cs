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
    public class GestionRepositorioLecturaBeneficiario : IGestionRepositorioLecturaBeneficiario
    {
        private string _cadenaConexion;
        private readonly IConfiguration _configuration;
        public GestionRepositorioLecturaBeneficiario(IConfiguration configuration)
        {
            _configuration = configuration;
            _cadenaConexion = _configuration["ConnectionStrings:ComodatoDatabaseLectura"];
        }
        public ResultadoDTO<Tuple<Beneficiario, string, short>> GetBeneficiarioPorId(short id)
        {
            short contador = 0;
            string mensajeBD = string.Empty;
            Beneficiario _Beneficiario = new Beneficiario();
            Tuple<Beneficiario, string, short> data = null;
            ResultadoDTO<Tuple<Beneficiario, string, short>> respuesta = new ResultadoDTO<Tuple<Beneficiario, string, short>>();
            List<Mensaje> mensajes = new List<Mensaje>();

            
            using (SqlConnection cn = new SqlConnection(_cadenaConexion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("SmcComodato_GetBeneficarioPorId", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Seteo de Parametros 
                    var paramIdParameter = new SqlParameter("@Id", id)
                    {
                        Direction = ParameterDirection.Input
                    };
                    cmd.Parameters.Add(paramIdParameter);

                    var outParamContador = new SqlParameter("@Contador", SqlDbType.SmallInt)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outParamContador);

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
                                    _Beneficiario = new Beneficiario();
                                    _Beneficiario.IdBeneficiario = Convert.ToInt16(drlector["IdBeneficiario"]);
                                    _Beneficiario.Nombre = Convert.ToString(drlector["Nombre"]);
                                    _Beneficiario.Identificacion = Convert.ToString(drlector["Identificacion"]);
                                    _Beneficiario.NombreRepresentante = Convert.ToString(drlector["NombreRepresentante"]);
                                    _Beneficiario.Contacto = Convert.ToString(drlector["Contacto"]);
                                    _Beneficiario.PdpEstado = Convert.ToBoolean(drlector["PdpEstado"]);
                                }
                            }
                            if (drlector != null)
                            {
                                drlector.Close();
                            }
                        }

                        mensajeBD = outParamMensaje.Value?.ToString();

                        string txtContador = outParamContador.Value?.ToString();

                        Int16.TryParse(txtContador, out contador);

                        data = new Tuple<Beneficiario, string, short>(_Beneficiario, mensajeBD, contador);
                    }
                    catch (Exception ex)
                    {
                        mensajes.Add(new Mensaje { codigo = "GRBIMPLINT001", descripcion = $"{ex.Message}" });
                        data = new Tuple<Beneficiario, string, short>(new Beneficiario(), string.Empty, 0);
                    }
                }
                cn.Close();
            }

            respuesta.dataresult = data;
            respuesta.mensajes = mensajes;

            return respuesta;
        }
        public ResultadoDTO<Beneficiario> GetBeneficiarioPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }
        public ResultadoDTO<Tuple<IList<Beneficiario>, int>> GetBeneficiarioTodosPaginado(BeneficiariosPanelFilterModel panelModel, int numeroPagina, int numeroFilas)
        {
            int totalPaginas = 0;
            List<Beneficiario> lsBeneficiario = new List<Beneficiario>();
            Tuple<IList<Beneficiario>, int> data = null;
            ResultadoDTO<Tuple<IList<Beneficiario>, int>> respuesta = new ResultadoDTO<Tuple<IList<Beneficiario>, int>>();
            List<Mensaje> mensajes = new List<Mensaje>();

            string strPanelFilterParameter = "";
            // Arma Datos de Cabecera
            var panelFilterParameter = new
            {
                nombre = panelModel.nombre,
                representante = panelModel.representante,
                ruc = panelModel.ruc,
                contacto = panelModel.contacto
            };
            strPanelFilterParameter = JsonSerializer.Serialize(panelFilterParameter);

            using (SqlConnection cn = new SqlConnection(_cadenaConexion))
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("SmcComodato_GetBeneficariosTodosPaginado", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Seteo de Parametros 
                    var paramPanelFilterParameter = new SqlParameter("@PanelFilter", strPanelFilterParameter)
                    {
                        Direction = ParameterDirection.Input
                    };
                    cmd.Parameters.Add(paramPanelFilterParameter);

                    var paramNumeroPagina = new SqlParameter("@NumeroPagina", numeroPagina)
                    {
                        Direction = ParameterDirection.Input
                    };
                    cmd.Parameters.Add(paramNumeroPagina);

                    var paramNumeroFila = new SqlParameter("@NumeroFilas", numeroFilas)
                    {
                        Direction = ParameterDirection.Input
                    };
                    cmd.Parameters.Add(paramNumeroFila);

                    var outParamMensaje = new SqlParameter("@TotalPaginas", SqlDbType.Int)
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
                                    var t = new Beneficiario();
                                    t.IdBeneficiario = Convert.ToInt16(drlector["IdBeneficiario"]);
                                    t.Nombre = Convert.ToString(drlector["Nombre"]);
                                    t.Identificacion = Convert.ToString(drlector["Identificacion"]);
                                    t.NombreRepresentante = Convert.ToString(drlector["NombreRepresentante"]);
                                    t.Contacto = Convert.ToString(drlector["Contacto"]);
                                    t.PdpEstado = Convert.ToBoolean(drlector["PdpEstado"]);
                                    lsBeneficiario.Add(t);
                                }
                            }
                            if (drlector != null)
                            {
                                drlector.Close();
                            }
                        }

                        string txtTotalPaginas = outParamMensaje.Value?.ToString();

                        Int32.TryParse(txtTotalPaginas, out totalPaginas);

                        data = new Tuple<IList<Beneficiario>, int>(lsBeneficiario, totalPaginas);
                    }
                    catch (Exception ex)
                    {
                        mensajes.Add(new Mensaje { codigo = "GRBIMPLINT001", descripcion =$"{ex.Message}"});
                        data = new Tuple<IList<Beneficiario>, int>(new List<Beneficiario>(), 0);
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
