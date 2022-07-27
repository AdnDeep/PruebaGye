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
        public ResultadoDTO<int> Eliminar(short id, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultado = new ResultadoDTO<int>();
            string parameters = string.Format("?idTramite={0}&usuario={1}&controlador={2}&pcclient={3}", id, usuario, controlador, pcclient);

            string urlResource = string.Concat(methodDelete, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .DeleteAsync(_baseAddress, resourceComodato, urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<int>(ref resultadoRepositorioExterno, "EliminarTramite", ref resultado);

            return resultado;
        }
    }
}
