using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        
        public TramiteReportClientViewModel ReporteGeneral(short id, string name)
        {
            TramiteReportClientViewModel resultadoVista = new TramiteReportClientViewModel();
            ResultadoDTO<TramiteReportServerViewModel> resultadoServidor = new ResultadoDTO<TramiteReportServerViewModel>();

            bool respValCli = _validadores.InputClientReportGetPorId(id, ref resultadoVista);

            if (!respValCli)
                return resultadoVista;

            var respRepExterno = _repositorioExterno.ObtenerReportePdfTramite(id, name);

            bool respValServ = _validadores.RespuestaReporteGeneralServidorRemotoById(ref respRepExterno, ref resultadoVista);

            if (!respValServ)
                return resultadoVista;

            _mapeadores.GenerateReportViewModel(ref respRepExterno, ref resultadoVista);

            return resultadoVista;
        }
    }
}
