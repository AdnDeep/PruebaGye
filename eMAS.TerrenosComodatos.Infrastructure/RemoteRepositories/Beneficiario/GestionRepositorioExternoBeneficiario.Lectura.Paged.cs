using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoBeneficiario : IGestionRepositorioExternoBeneficiario
    {
        public ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> GetBeneficiarioTodosPaginado(string panelFilter, string resultContainer, int numeroPagina, int numeroFila)
        {
            ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> resultado = new ResultadoDTO<DataPagineada<BeneficiarioListViewModel>>();
            string parameters = string.Format("?panelFilter={0}&resultContainer={1}&numeroPagina={2}&numeroFila={3}", panelFilter, resultContainer, numeroPagina, numeroFila);

            string urlResource = string.Concat(methodGetPaged, parameters);
            
            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .GetAsync(_baseAddress, "", urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<DataPagineada<BeneficiarioListViewModel>>(ref resultadoRepositorioExterno, "GetBeneficiarioTodosPaginado", ref resultado);
            
            return resultado;
        }
    }
}
