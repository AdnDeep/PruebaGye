using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        public ResultadoDTO<TopografiaTerrenoEditViewMoel> GetTopografiaPorId(short id)
        {
            ResultadoDTO<TopografiaTerrenoEditViewMoel> resultado = new ResultadoDTO<TopografiaTerrenoEditViewMoel>();
            string parameters = string.Format("?id={0}", id);

            string urlResource = string.Concat(methodTopografiaGetById, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .GetAsync(_baseAddress, "", urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<TopografiaTerrenoEditViewMoel>(ref resultadoRepositorioExterno, "GetTopografiaPorId", ref resultado);

            return resultado;
        }
    }
}
