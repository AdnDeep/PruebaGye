using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public interface ICasesUsesGestionTramite
    {
        ResultadoDTO<DataPagineada<TramiteListViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFila);

        ResultadoDTO<TramiteEditViewModel> LeerPorId(short id);
    }
}
