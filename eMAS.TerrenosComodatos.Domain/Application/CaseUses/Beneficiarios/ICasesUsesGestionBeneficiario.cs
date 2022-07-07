using eMAS.TerrenosComodatos.Domain.DTOs;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public interface ICasesUsesGestionBeneficiario
    {
        ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> LeerTodosPaginado(string dataPanel, string resultContainer, int numeroPagina, int numeroFila);
        ResultadoDTO<BeneficiarioEditViewModel> LeerPorId(short id);
        ResultadoDTO<BeneficiarioEditViewModel> GrabarBeneficiario(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<BeneficiarioEditViewModel> EliminarBeneficiario(BeneficiarioDeleteViewModel model, string usuario, string controlador, string pcclient);
    }
}
