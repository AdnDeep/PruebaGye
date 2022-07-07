using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoBeneficiario : IGestionRepositorioExternoBeneficiario
    {
        public ResultadoDTO<BeneficiarioEditViewModel> EliminarBeneficiario(short id, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<BeneficiarioEditViewModel> resultado = new ResultadoDTO<BeneficiarioEditViewModel>();
            string parameters = string.Format("?id={0}&usuario={1}&controlador={2}&pcclient={3}", id, usuario, controlador, pcclient);

            string urlResource = string.Concat(methodPost, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .DeleteAsync(_baseAddress, "", urlResource)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<BeneficiarioEditViewModel>(ref resultadoRepositorioExterno, "EliminarBeneficiario", ref resultado);

            return resultado;
        }
    }
}
