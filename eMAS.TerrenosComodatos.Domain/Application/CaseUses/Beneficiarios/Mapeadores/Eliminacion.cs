
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresBeneficiario
    {
        public void GenerateEditViewModelAfterDelete(ref ResultadoDTO<BeneficiarioEditViewModel> model
            , ref ResultadoDTO<BeneficiarioEditViewModel> salida)
        {
            salida.tipo = model.tipo;
            salida.mensaje = model.mensaje;
            salida.dataresult = model.dataresult;
        }
    }
}
