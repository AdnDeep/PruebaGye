using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        
        public ResultadoDTO<TramiteEditViewModel> LeerPorId(short id)
        {
            TramiteEditViewModel modelo = null;
            ResultadoDTO<TramiteEditViewModel> resultadoVista = new ResultadoDTO<TramiteEditViewModel>();

            bool respValCli = _validadores.InputClientGetPorId(id, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;

            if (id == 0)
            {
                modelo = new TramiteEditViewModel();

                _mapeadores.GenerateEditViewModelEmpty(ref modelo);

                resultadoVista.dataresult = modelo;
            }
            else if (id > 0)
            {
                var respRepExterno = _repositorioExterno.GetPorId(id);

                bool respValServ = _validadores.RespuestaServidorRemotoById(ref respRepExterno, ref resultadoVista);

                if (!respValServ)
                    return resultadoVista;

                _mapeadores.GenerateEditViewModel(ref respRepExterno, ref resultadoVista);
            }


            return resultadoVista;
        }
    }
}
