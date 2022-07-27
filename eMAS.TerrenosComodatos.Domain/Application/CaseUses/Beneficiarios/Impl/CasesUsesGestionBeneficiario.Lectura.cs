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

            bool respValCli = _validadores.InputClientGetById(id, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;

            if (id == 0)
            {
                modelo = new BeneficiarioEditViewModel();

                _mapeadores.GenerateEditViewModelEmpty(ref modelo);

                resultadoVista.dataresult = modelo;
            }
            else if (id > 0)
            {
                var respRepExterno = _repositorioExterno.GetBeneficiarioPorId(id);

                bool respValServ = _validadores.RespuestaServidorRemotoById(ref respRepExterno, ref resultadoVista);

                if (!respValServ)
                    return resultadoVista;

                _mapeadores.GenerateEditViewModel(ref respRepExterno, ref resultadoVista);
            }


            return resultadoVista;
        }
    }
}
