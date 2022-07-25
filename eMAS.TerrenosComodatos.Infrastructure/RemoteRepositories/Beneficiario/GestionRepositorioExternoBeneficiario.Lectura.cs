using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoBeneficiario : IGestionRepositorioExternoBeneficiario
    {
        public ResultadoDTO<BeneficiarioEditViewModel> GetBeneficiarioPorId(short id)
        {
            ResultadoDTO<BeneficiarioEditViewModel> resultado = new ResultadoDTO<BeneficiarioEditViewModel>();
            string parameters = string.Format("?id={0}", id);

            string urlResource = string.Concat(methodGetById, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .GetAsync(_baseAddress, resourceComodato, urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<BeneficiarioEditViewModel>(ref resultadoRepositorioExterno, "GetBeneficiarioPorId", ref resultado);

            return resultado;
        }
    }
}
