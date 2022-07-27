using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        public ResultadoDTO<AnexoTramiteEditViewModel> LeerDetalleAnexoPorId(short identidad)        
        {
            AnexoTramiteEditViewModel modelo = null;
            ResultadoDTO<AnexoTramiteEditViewModel> resultadoVista = new ResultadoDTO<AnexoTramiteEditViewModel>();
            /*
            bool respValCli = _validadores.InputClienteGetDetailPorId(identidad, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;
            */
            if (identidad == 0)
            {
                modelo = new AnexoTramiteEditViewModel();

                _mapeadores.GenerateEditViewModelEmptyAnexo(ref modelo);

                resultadoVista.dataresult = modelo;
            }
            else if (identidad > 0)
            {
                var respRepExterno = _repositorioExterno.GetAnexoPorId(identidad);

                bool respValServ = _validadores.RespuestaServidorRemotoDetailById(ref respRepExterno, ref resultadoVista);

                if (!respValServ)
                    return resultadoVista;

                _mapeadores.GenerateEditViewModelDetail(ref respRepExterno, ref resultadoVista);
            }
            return resultadoVista;
        }
    }
}
