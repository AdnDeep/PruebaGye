using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoTramite : IGestionRepositorioExternoTramite
    {
        public ResultadoDTO<TramiteReportServerViewModel> ObtenerReportePdfTramite(short id)
        {
            ResultadoDTO<TramiteReportServerViewModel> resultado = new ResultadoDTO<TramiteReportServerViewModel>();
            string parameters = string.Format("?idEntity={0}", id);

            string urlResource = string.Concat(methodReporteGeneralPdf, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .GetAsync(_baseAddress, "", urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<TramiteReportServerViewModel>(ref resultadoRepositorioExterno, "TramiteReportServerViewModel", ref resultado);

            return resultado;
        }
    }
}
