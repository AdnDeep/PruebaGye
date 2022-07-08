using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        public ResultadoDTO<List<TopografiaTerrenoListViewMoel>> GetTopografiasPorIdTramite(short id)
        {
            ResultadoDTO<List<TopografiaTerrenoListViewMoel>> resultado = new ResultadoDTO<List<TopografiaTerrenoListViewMoel>>();
            string parameters = string.Format("?id={0}", id);

            string urlResource = string.Concat(methodTopografiaGetAllByIdTramite, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .GetAsync(_baseAddress, "", urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<List<TopografiaTerrenoListViewMoel>>(ref resultadoRepositorioExterno, "GetTopografiasPorIdTramite", ref resultado);

            return resultado;
        }
    }
}
