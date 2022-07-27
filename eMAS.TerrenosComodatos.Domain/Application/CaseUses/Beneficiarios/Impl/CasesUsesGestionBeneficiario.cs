using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionBeneficiario : ICasesUsesGestionBeneficiario
    {
        private readonly IGestionRepositorioExternoBeneficiario _repositorioExterno;
        private readonly ValidadoresBeneficiario _validadores;
        private readonly MapeadoresBeneficiario _mapeadores;
        private readonly ILogger<CasesUsesGestionBeneficiario> _logger;
        public CasesUsesGestionBeneficiario(ILogger<CasesUsesGestionBeneficiario> logger
            , MapeadoresBeneficiario mapeadores
            , ValidadoresBeneficiario validadores
            , IGestionRepositorioExternoBeneficiario repositorioExterno)
        {
            _repositorioExterno = repositorioExterno;
            _validadores = validadores;
            _mapeadores = mapeadores;
            _logger = logger;
        }
    }
}
