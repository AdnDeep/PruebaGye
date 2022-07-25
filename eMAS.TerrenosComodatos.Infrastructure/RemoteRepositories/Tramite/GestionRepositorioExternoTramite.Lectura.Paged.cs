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
        public ResultadoDTO<DataPagineada<TramiteListViewModel>> GetVistaTodosPaginado(string panelModel, string resultContainer, int numeroPagina, int numeroFilas)
        {
            ResultadoDTO<DataPagineada<TramiteListViewModel>> resultado = new ResultadoDTO<DataPagineada<TramiteListViewModel>>();
            string parameters = string.Format("?panelFilter={0}&resultContainer={1}&numeroPagina={2}&numeroFila={3}", panelModel, resultContainer, numeroPagina, numeroFilas);

            string urlResource = string.Concat(methodGetPaged, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .GetAsync(_baseAddress, resourceComodato, urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<DataPagineada<TramiteListViewModel>>(ref resultadoRepositorioExterno, "GetTramitesVistaTodosPaginado", ref resultado);

            return resultado;
        }
    }
}
