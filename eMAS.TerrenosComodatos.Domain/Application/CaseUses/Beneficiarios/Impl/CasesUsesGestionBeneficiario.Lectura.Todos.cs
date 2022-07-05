using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionBeneficiario : ICasesUsesGestionBeneficiario
    {
        public ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFila)
        {
            throw new System.NotImplementedException();
        }
    }
}
