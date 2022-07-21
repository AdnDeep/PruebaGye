using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        public ResultadoDTO<OficioTramiteEditViewModel> LeerDetalleOficioPorId(short identidad)        
        {
            OficioTramiteEditViewModel modelo = null;
            ResultadoDTO<OficioTramiteEditViewModel> resultadoVista = new ResultadoDTO<OficioTramiteEditViewModel>();
            /*
            bool respValCli = _validadores.InputClienteGetDetailPorId(identidad, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;
            */
            if (identidad == 0)
            {
                modelo = new OficioTramiteEditViewModel();

                _mapeadores.GenerateEditViewModelEmptyOficio(ref modelo);

                resultadoVista.dataresult = modelo;
            }
            else if (identidad > 0)
            {
                var respRepExterno = _repositorioExterno.GetOficioPorId(identidad);

                bool respValServ = _validadores.RespuestaServidorRemotoDetailById(ref respRepExterno, ref resultadoVista);

                if (!respValServ)
                    return resultadoVista;

                _mapeadores.GenerateEditViewModelDetail(ref respRepExterno, ref resultadoVista);

                _mapeadores.DataLecturaOficio(ref resultadoVista);
            }
            return resultadoVista;
        }
    }
}
