
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresBeneficiario
    {
        private readonly ILogger<MapeadoresBeneficiario> _logger;
        public MapeadoresBeneficiario(ILogger<MapeadoresBeneficiario> logger)
        {
            _logger = logger;
        }
        public void GenerateEditViewModelEmpty(ref BeneficiarioEditViewModel model)
        {
            model.id = 0;
        }
        public void GenerateEditViewModel(ref ResultadoDTO<BeneficiarioEditViewModel> model
            , ref ResultadoDTO<BeneficiarioEditViewModel> salida)
        {
            salida.tipo = model.tipo;
            salida.mensaje = model.mensaje;
            salida.dataresult = model.dataresult;
        }
    }
}
