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
        public ResultadoDTO<ObservacionTramiteEditViewModel> GetObservacionPorId(short id)
        {
            ResultadoDTO<ObservacionTramiteEditViewModel> resultado = new ResultadoDTO<ObservacionTramiteEditViewModel>();
            string parameters = string.Format("?id={0}", id);

            string urlResource = string.Concat(methodObservacionGetById, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .GetAsync(_baseAddress, resourceComodato, urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<ObservacionTramiteEditViewModel>(ref resultadoRepositorioExterno, "GetObservacionPorId", ref resultado);

            return resultado;
        }
    }
}
