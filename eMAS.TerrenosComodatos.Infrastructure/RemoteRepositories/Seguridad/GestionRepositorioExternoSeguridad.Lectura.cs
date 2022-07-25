using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoSeguridad : IGestionRepositorioExternoSeguridad
    {
        public ResultadoViewModel ObtenerPermisoPorUsuario(string user, string controlador)
        {
            ResultadoViewModel resultado = new ResultadoViewModel();
            string parameters = $"/{user}/{controlador}";

            string urlResource = string.Concat(methodGetPermisoByUsuario, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .GetAsync(_baseAddress, resourceSeguridad, urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<ResultadoViewModel>(ref resultadoRepositorioExterno, "ObtenerPermisoPorUsuario", ref resultado);

            return resultado;
        }
    }
}
