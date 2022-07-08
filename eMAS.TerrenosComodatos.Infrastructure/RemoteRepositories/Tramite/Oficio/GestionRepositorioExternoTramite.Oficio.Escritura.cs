using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        public ResultadoDTO<int> CrearOficio(OficioTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultado = new ResultadoDTO<int>();
            string parameters = string.Format("?usuario={0}&controlador={1}&pcclient={2}", usuario, controlador, pcclient);

            string urlResource = string.Concat(methodOficioPost, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .PostAsync(_baseAddress, "", urlResource, model)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<int>(ref resultadoRepositorioExterno, "CrearOficio", ref resultado);

            return resultado;
        }

        public ResultadoDTO<int> ActualizarOficio(OficioTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultado = new ResultadoDTO<int>();
            string parameters = string.Format("?usuario={0}&controlador={1}&pcclient={2}", usuario, controlador, pcclient);

            string urlResource = string.Concat(methodOficioPut, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .PutAsync(_baseAddress, "", urlResource, model)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<int>(ref resultadoRepositorioExterno, "ActualizarOficio", ref resultado);

            return resultado;
        }

    }
}
