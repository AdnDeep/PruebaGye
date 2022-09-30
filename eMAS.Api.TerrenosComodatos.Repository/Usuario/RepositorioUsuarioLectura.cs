using eMAS.Api.TerrenosComodatos.ViewModel;
using System;
using System.Collections.Generic;
using System.Text.Json;
using eMAS.Api.TerrenosComodatos.IRepository;
using System.Threading.Tasks;
using eMAS.Api.TerrenosComodatos.Comun;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace eMAS.Api.TerrenosComodatos.Repository
{
    public partial class RepositorioUsuarioLectura : IGestionRepositorioLecturaUsuarios
    {
        const string resourceComodato = "ApiScopes:ApiSeguridadScope";
        private readonly string _baseAddress;
        private readonly ILogger<RepositorioUsuarioLectura> _logger;
        const string methodGetProfileByUser = "api/Usuario/ObtenerPerfilOpciones";
        private readonly ApiService _apiService;
        public RepositorioUsuarioLectura(ApiService apiService
            , IConfiguration configuration
            , ILogger<RepositorioUsuarioLectura> logger)
        {
            _logger = logger;
            _baseAddress = configuration["URLSeguridad"];
            _apiService = apiService;
        }

        public async Task<RespuestaViewModel<List<UsuarioPerfilOpcion>>> GetPerfilesOpcionesPorUsuario(string usuarioId)
        {
            string parameters = string.Format("?usuarioId={0}", usuarioId);

            string urlResource = string.Concat(methodGetProfileByUser, parameters);

            var resultSerialized = await _apiService.GetAsync(_baseAddress, resourceComodato, urlResource);
            
            var respuestaProcesada = ProcesaRespuestaServidorRemoto(ref resultSerialized, "GetPerfilesOpcionesPorUsuario");

            return respuestaProcesada;
        }
        private RespuestaViewModel<List<UsuarioPerfilOpcion>> ProcesaRespuestaServidorRemoto(ref Tuple<int, string> entrada
            , string metodo)
        {
            RespuestaViewModel<List<UsuarioPerfilOpcion>> respuestaRemota = new RespuestaViewModel<List<UsuarioPerfilOpcion>>();
            var parametros = $"GetPerfilesOpcionesPorUsuario Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "GetPerfilesOpcionesPorUsuario" },
                                { "Sitio", "API-COMODATO" },
                                { "Parametros", parametros }
                        };
            if (entrada == null)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}.La respuesta desde el servidor es NULO.");
                }
                respuestaRemota.Resultado.Ok = false;
                respuestaRemota.Resultado.ErrorValidacion = false;
                respuestaRemota.Resultado.Titulo = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [1]";
                respuestaRemota.Resultado.Mensajes.Add("LOGINTERNO||El objeto está vacío");
                return respuestaRemota;
            }
            if (entrada.Item1 == 204)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. Se produjo un error la respuesta está vacía desde el servidor.");
                }
                respuestaRemota.Resultado.Ok = false;
                respuestaRemota.Resultado.ErrorValidacion = false;
                respuestaRemota.Resultado.Titulo = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [2]";
                respuestaRemota.Resultado.Mensajes.Add("LOGINTERNO||El objeto devolvió código 204");
                return respuestaRemota;
            }
            if (entrada.Item1 == 500)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. Se produjo una excepción {entrada.Item2}");
                }
                respuestaRemota.Resultado.Ok = false;
                respuestaRemota.Resultado.ErrorValidacion = false;
                respuestaRemota.Resultado.Titulo = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [3]";
                respuestaRemota.Resultado.Mensajes.Add("LOGINTERNO||El objeto devolvió código 500");
                return respuestaRemota;
            }
            if (entrada.Item1 == 404)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. El recurso solicitado no existe.");
                }
                respuestaRemota.Resultado.Ok = false;
                respuestaRemota.Resultado.ErrorValidacion = false;
                respuestaRemota.Resultado.Titulo = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [4]";
                respuestaRemota.Resultado.Mensajes.Add("LOGINTERNO||El objeto devolvió código 404");
                return respuestaRemota;
            }
            if (entrada.Item1 == 401)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. El recurso solicitado no existe.");
                }
                respuestaRemota.Resultado.Ok = false;
                respuestaRemota.Resultado.ErrorValidacion = false;
                respuestaRemota.Resultado.Titulo = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [5]";
                respuestaRemota.Resultado.Mensajes.Add("LOGINTERNO||El objeto devolvió código 401");
                respuestaRemota.Resultado.Mensajes.Add("MENSAJEUSUARIO||Por motivo de permisos no se ha podido acceder al recurso solicitado.");
                return respuestaRemota;
            }
            if (string.IsNullOrEmpty(entrada.Item2) || string.IsNullOrWhiteSpace(entrada.Item2))
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: {metodo}. La respuesta desde el servidor está vacío");
                }
                respuestaRemota.Resultado.Ok = false;
                respuestaRemota.Resultado.ErrorValidacion = false;
                respuestaRemota.Resultado.Titulo = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [6]";
                respuestaRemota.Resultado.Mensajes.Add("LOGINTERNO||La respuesta está vacía.");
                return respuestaRemota;
            }
            string contenidoRespuestaServidor = entrada.Item2;
            try
            {
                respuestaRemota = JsonSerializer.Deserialize<RespuestaViewModel<List<UsuarioPerfilOpcion>>>(contenidoRespuestaServidor);
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Error procesando el método: ProcesaRespuestaServidorRemoto. Excepcion {ex.Message}");
                }
                respuestaRemota.Resultado.Ok = false;
                respuestaRemota.Resultado.ErrorValidacion = false;
                respuestaRemota.Resultado.Titulo = "Se ha producido un inconveniente en el aplicativo, favor intente de nuevo en unos minutos [7]";
                respuestaRemota.Resultado.Mensajes.Add("LOGINTERNO||Se produjo un error deserializando el objeto.");
                return respuestaRemota;
            }
            respuestaRemota.Resultado.Ok = true;
            respuestaRemota.Resultado.ErrorValidacion = false;
            respuestaRemota.Resultado.Titulo = "OK";
            return respuestaRemota;
        }
    }
}