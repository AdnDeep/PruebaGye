
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;

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

        }
    }
}
