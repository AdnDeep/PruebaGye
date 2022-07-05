using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public interface ICasesUsesGestionTramite
    {
        ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFila);

        ResultadoDTO<BeneficiarioEditViewModel> LeerPorId(short id);
    }
}
