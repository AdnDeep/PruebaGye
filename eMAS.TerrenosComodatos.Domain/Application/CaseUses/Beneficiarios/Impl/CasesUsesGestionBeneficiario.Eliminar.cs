using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionBeneficiario : ICasesUsesGestionBeneficiario
    {
        public ResultadoDTO<BeneficiarioEditViewModel> EliminarBeneficiario(BeneficiarioDeleteViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<BeneficiarioEditViewModel> resultadoVista = new ResultadoDTO<BeneficiarioEditViewModel>();

            bool respValCli = _validadores.DataClienteEliminacion(ref model, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;
            var respServRemoto = _repositorioExterno.EliminarBeneficiario(model.id, usuario, controlador, pcclient);
            
            bool valRespServ = _validadores.RespuestaServidorRemotoEscritura(ref respServRemoto, ref resultadoVista);

            if (!valRespServ)
                return resultadoVista;

            _mapeadores.GenerateEditViewModelAfterSave(ref respServRemoto, ref resultadoVista);

            return resultadoVista;
        }

    }
}
