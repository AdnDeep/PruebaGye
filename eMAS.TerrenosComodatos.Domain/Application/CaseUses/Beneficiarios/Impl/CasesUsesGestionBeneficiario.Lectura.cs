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
                _mapeadores.GenerateEditViewModelEmpty(ref modelo);
            }
            else if (id > 0)
            {
            }
            else
            { 
            }
            
            resultadoVista.dataresult = modelo;

            return resultadoVista;
        }
    }
}
