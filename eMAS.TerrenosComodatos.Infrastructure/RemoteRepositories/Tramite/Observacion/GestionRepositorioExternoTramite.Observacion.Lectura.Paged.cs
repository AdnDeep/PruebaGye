﻿using eMAS.TerrenosComodatos.Domain.DTOs;
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
        public ResultadoDTO<List<ObservacionTramiteListViewModel>> GetObservacionsPorIdTramite(short id)
        {
            ResultadoDTO<List<ObservacionTramiteListViewModel>> resultado = new ResultadoDTO<List<ObservacionTramiteListViewModel>>();
            string parameters = string.Format("?id={0}", id);

            string urlResource = string.Concat(methodObservacionGetAllByIdTramite, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .GetAsync(_baseAddress, resourceComodato, urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<List<ObservacionTramiteListViewModel>>(ref resultadoRepositorioExterno, "GetObservacionsPorIdTramite", ref resultado);

            return resultado;
        }
    }
}
