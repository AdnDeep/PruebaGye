using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Infrastructure.RemoteRepositories
{
    public partial class GestionRepositorioExternoBeneficiario : IGestionRepositorioExternoBeneficiario
    {
        public ResultadoDTO<BeneficiarioEditViewModel> ActualizarBeneficiario(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<BeneficiarioEditViewModel> resultado = new ResultadoDTO<BeneficiarioEditViewModel>();
            string parameters = string.Format("?usuario={0}&controlador={1}&pcclient={2}", usuario, controlador, pcclient);

            string urlResource = string.Concat(methodPost, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .PutAsync(_baseAddress, "", urlResource, model)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<BeneficiarioEditViewModel>(ref resultadoRepositorioExterno, "ActualizarBeneficiario", ref resultado);

            return resultado;
        }

        public ResultadoDTO<BeneficiarioEditViewModel> CrearBeneficiario(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<BeneficiarioEditViewModel> resultado = new ResultadoDTO<BeneficiarioEditViewModel>();
            string parameters = string.Format("?usuario={0}&controlador={1}&pcclient={2}", usuario, controlador, pcclient);

            string urlResource = string.Concat(methodPost, parameters);

            // Consume Método de Api Service
            var resultadoRepositorioExterno = Task.Run(async () => await _clientHttpSvc
                                                    .PostAsync(_baseAddress, "", urlResource, model)).Result;
            // Procesa Respuesta
            ProcesaRespuestaServidorRemoto<BeneficiarioEditViewModel>(ref resultadoRepositorioExterno, "CrearBeneficiario", ref resultado);

            return resultado;
        }
    }
}
