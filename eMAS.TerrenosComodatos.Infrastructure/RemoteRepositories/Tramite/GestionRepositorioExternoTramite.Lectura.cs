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
        public ResultadoDTO<TramiteEditViewModel> GetPorId(short id)
        {
            ResultadoDTO<TramiteEditViewModel> resultado = new ResultadoDTO<TramiteEditViewModel>();
            string parameters = string.Format("?id={0}", id);

            string urlResource = string.Concat(methodGetById, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .GetAsync(_baseAddress, "", urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<TramiteEditViewModel>(ref resultadoRepositorioExterno, "GetTramitePorId", ref resultado);

            return resultado;
        }
    }
}
