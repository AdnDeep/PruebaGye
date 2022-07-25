using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        public ResultadoDTO<List<OficioTramiteListViewModel>> GetOficiosPorIdTramite(short id)
        {
            ResultadoDTO<List<OficioTramiteListViewModel>> resultado = new ResultadoDTO<List<OficioTramiteListViewModel>>();
            string parameters = string.Format("?id={0}", id);

            string urlResource = string.Concat(methodOficioGetAllByIdTramite, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .GetAsync(_baseAddress, resourceComodato, urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<List<OficioTramiteListViewModel>>(ref resultadoRepositorioExterno, "GetOficiosPorIdTramite", ref resultado);

            return resultado;
        }
    }
}
