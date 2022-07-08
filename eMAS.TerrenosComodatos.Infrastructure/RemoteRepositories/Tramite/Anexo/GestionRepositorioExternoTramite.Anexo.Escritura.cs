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
        public ResultadoDTO<int> CrearAnexo(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultado = new ResultadoDTO<int>();
            string parameters = string.Format("?usuario={0}&controlador={1}&pcclient={2}", usuario, controlador, pcclient);

            string urlResource = string.Concat(methodAnexoPost, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .PostAsync(_baseAddress, "", urlResource, model)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<int>(ref resultadoRepositorioExterno, "CrearAnexo", ref resultado);

            return resultado;
        }

        public ResultadoDTO<int> ActualizarAnexo(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> resultado = new ResultadoDTO<int>();
            string parameters = string.Format("?usuario={0}&controlador={1}&pcclient={2}", usuario, controlador, pcclient);

            string urlResource = string.Concat(methodAnexoPut, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .PutAsync(_baseAddress, "", urlResource, model)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<int>(ref resultadoRepositorioExterno, "ActualizarAnexo", ref resultado);

            return resultado;
        }

    }
}
