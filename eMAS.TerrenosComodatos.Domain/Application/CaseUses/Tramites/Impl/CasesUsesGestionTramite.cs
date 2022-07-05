using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        public ResultadoDTO<BeneficiarioEditViewModel> LeerPorId(short id)
        {
            throw new System.NotImplementedException();
        }

        public ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFila)
        {
            throw new System.NotImplementedException();
        }
    }
}
