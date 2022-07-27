using eMAS.TerrenosComodatos.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class CasesUsesGestionTramite : ICasesUsesGestionTramite
    {
        private readonly IGestionRepositorioExternoTramite _repositorioExterno;
        private readonly ValidadoresTramite _validadores;
        private readonly MapeadoresTramite _mapeadores;
        private readonly ILogger<CasesUsesGestionTramite> _logger;
        public CasesUsesGestionTramite(ILogger<CasesUsesGestionTramite> logger
            , MapeadoresTramite mapeadores
            , ValidadoresTramite validadores
            , IGestionRepositorioExternoTramite repositorioExterno)
        {
            _repositorioExterno = repositorioExterno;
            _validadores = validadores;
            _mapeadores = mapeadores;
            _logger = logger;
        }
    }
}
