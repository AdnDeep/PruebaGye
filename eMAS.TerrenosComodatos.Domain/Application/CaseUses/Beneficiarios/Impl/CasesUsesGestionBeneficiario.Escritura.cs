using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionBeneficiario : ICasesUsesGestionBeneficiario
    {
        public ResultadoDTO<BeneficiarioEditViewModel> GrabarBeneficiario(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<BeneficiarioEditViewModel> resultadoVista = new ResultadoDTO<BeneficiarioEditViewModel>();

            bool respValCli = _validadores.DataClienteEscritura(ref model, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;
            ResultadoDTO<BeneficiarioEditViewModel> respServRemoto = new ResultadoDTO<BeneficiarioEditViewModel>();
            if (model.id == 0)
            {
                respServRemoto= _repositorioExterno.CrearBeneficiario(model, usuario, controlador, pcclient);
            }
            else if (model.id > 0)
            {
                respServRemoto= _repositorioExterno.ActualizarBeneficiario(model, usuario, controlador, pcclient);
            }

            bool valRespServ = _validadores.RespuestaServidorRemotoEscritura(ref respServRemoto, ref resultadoVista);

            if (!valRespServ)
                return resultadoVista;

            _mapeadores.GenerateEditViewModelAfterSave(ref respServRemoto, ref resultadoVista);

            return resultadoVista;
        }
    }
}
