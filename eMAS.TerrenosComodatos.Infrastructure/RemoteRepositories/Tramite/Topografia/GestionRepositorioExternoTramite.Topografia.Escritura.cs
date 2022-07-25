using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        public ResultadoDTO<int> CrearTopografia(TopografiaTerrenoEditViewMoel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultado = new ResultadoDTO<int>();
            string parameters = string.Format("?usuario={0}&controlador={1}&pcclient={2}", usuario, controlador, pcclient);

            string urlResource = string.Concat(methodTopografiaPost, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .PostAsync(_baseAddress, resourceComodato, urlResource, model)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<int>(ref resultadoRepositorioExterno, "CrearTopografia", ref resultado);

            return resultado;
        }

        public ResultadoDTO<int> ActualizarTopografia(TopografiaTerrenoEditViewMoel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultado = new ResultadoDTO<int>();
            string parameters = string.Format("?usuario={0}&controlador={1}&pcclient={2}", usuario, controlador, pcclient);

            string urlResource = string.Concat(methodTopografiaPut, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .PutAsync(_baseAddress, resourceComodato, urlResource, model)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<int>(ref resultadoRepositorioExterno, "ActualizarTopografia", ref resultado);

            return resultado;
        }

    }
}
