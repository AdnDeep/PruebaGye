using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        public ResultadoDTO<OficioTramiteEditViewModel> GetOficioPorId(short id)
        {
            ResultadoDTO<OficioTramiteEditViewModel> resultado = new ResultadoDTO<OficioTramiteEditViewModel>();
            string parameters = string.Format("?id={0}", id);

            string urlResource = string.Concat(methodOficioGetById, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .GetAsync(_baseAddress, "", urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<OficioTramiteEditViewModel>(ref resultadoRepositorioExterno, "GetOficioPorId", ref resultado);

            return resultado;
        }
    }
}
