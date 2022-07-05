
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application.CaseUses
{
    public partial class ValidadoresBeneficiario
    {
        private readonly ILogger<ValidadoresBeneficiario> _logger;
        public ValidadoresBeneficiario(ILogger<ValidadoresBeneficiario> logger)
        {
            _logger = logger;
        }
    }
}
