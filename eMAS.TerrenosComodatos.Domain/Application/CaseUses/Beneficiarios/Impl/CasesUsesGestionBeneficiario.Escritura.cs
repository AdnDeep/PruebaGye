using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionBeneficiario : ICasesUsesGestionBeneficiario
    {
        public ResultadoDTO<BeneficiarioEditViewModel> GrabarBeneficiario(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient)
        {
            throw new System.NotImplementedException();
        }
    }
}
