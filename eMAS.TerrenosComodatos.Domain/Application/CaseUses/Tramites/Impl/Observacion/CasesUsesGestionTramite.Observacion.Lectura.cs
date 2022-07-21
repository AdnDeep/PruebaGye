using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        public ResultadoDTO<ObservacionTramiteEditViewModel> LeerDetalleObservacionPorId(short identidad)        
        {
            ObservacionTramiteEditViewModel modelo = null;
            ResultadoDTO<ObservacionTramiteEditViewModel> resultadoVista = new ResultadoDTO<ObservacionTramiteEditViewModel>();
            /*
            bool respValCli = _validadores.InputClienteGetDetailPorId(identidad, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;
            */
            if (identidad == 0)
            {
                modelo = new ObservacionTramiteEditViewModel();

                _mapeadores.GenerateEditViewModelEmptyObservacion(ref modelo);

                resultadoVista.dataresult = modelo;
            }
            else if (identidad > 0)
            {
                var respRepExterno = _repositorioExterno.GetObservacionPorId(identidad);

                bool respValServ = _validadores.RespuestaServidorRemotoDetailById(ref respRepExterno, ref resultadoVista);

                if (!respValServ)
                    return resultadoVista;

                _mapeadores.GenerateEditViewModelDetail(ref respRepExterno, ref resultadoVista);

                _mapeadores.DataLecturaObservacion(ref resultadoVista);
            }
            return resultadoVista;
        }
    }
}
