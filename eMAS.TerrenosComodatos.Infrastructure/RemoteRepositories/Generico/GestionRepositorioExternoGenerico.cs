using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoGenerico : IGestionRepositorioExternoGenerico
    {
        private const string methodGetDataDsr = "api/SingleSelector/GetDataDsr";
        private readonly string _baseAddress;
        private readonly ILogger<GestionRepositorioExternoGenerico> _logger;
        private readonly ApiService _clientHttpSvc;
        public GestionRepositorioExternoGenerico(ApiService clientHttpSvc
            , IConfiguration configuration
            , ILogger<GestionRepositorioExternoGenerico> logger)
        {
            _logger = logger;
            _baseAddress = configuration["ApiComodato:ApiBaseAddress"];
            _clientHttpSvc = clientHttpSvc;
        }
        public ResultadoDTO<StructKeyValueSelect> ObtenerListadoGenerico(string keyparam, string keyentity, string target)
        {
            ResultadoDTO<StructKeyValueSelect> resultado = new ResultadoDTO<StructKeyValueSelect>();
            string parameters = string.Format("?key1={0}&keyEntity={1}&target={2}", keyparam, keyentity, target);

            string urlResource = string.Concat(methodGetDataDsr, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                            .GetAsync(_baseAddress, "", urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<StructKeyValueSelect>(ref resultadoRepositorioExterno, "ObtenerListadoGenerico", ref resultado);

            return resultado;
        }
    }
}
