using eMAS.Api.TerrenosComodatos.ViewModel;

namespace eMAS.Api.TerrenosComodatos.IServices
{
    public interface IServiceBeneficiarioLecturaTodos
    {
        ResultadoDTO<DataPagineada<BeneficiariosListViewModel>> ConsultarBeneficiariosTodosPaginado(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila);
        ResultadoDTO<BeneficiarioEditViewModel> ConsultarPorId(short id);
    }
}
