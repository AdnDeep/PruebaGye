using eMAS.Api.TerrenosComodatos.ViewModel;

namespace eMAS.Api.TerrenosComodatos.IServices
{
    public interface IServiceBeneficiarioEscritura
    {
        ResultadoDTO<BeneficiarioEditViewModel> Agregar(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient);
        ResultadoDTO<BeneficiarioEditViewModel> Actualizar(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient);
    }
}
