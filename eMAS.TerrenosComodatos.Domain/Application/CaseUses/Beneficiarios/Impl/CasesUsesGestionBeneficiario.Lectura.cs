using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionBeneficiario : ICasesUsesGestionBeneficiario
    {
        public ResultadoDTO<BeneficiarioEditViewModel> LeerPorId(short id)
        {
            BeneficiarioEditViewModel modelo = null;
            ResultadoDTO<BeneficiarioEditViewModel> resultadoVista = new ResultadoDTO<BeneficiarioEditViewModel>();
            if (id == 0)
            {
                modelo = new BeneficiarioEditViewModel();

            }
            else if (id > 0)
            {
            }
            else
            { 
            }
            return resultadoVista;
        }
    }
}
