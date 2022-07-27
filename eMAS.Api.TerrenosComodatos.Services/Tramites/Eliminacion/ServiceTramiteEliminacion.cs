using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic;
using Microsoft.Extensions.Logging;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ServiceTramiteEliminacion : IServiceTramiteEliminacion
    {
        private readonly MapeadoresEliminacionTramite _mapeadores;
        private readonly ValidadoresEliminacionTramite _validadores;
        private readonly TramiteLogicEliminacion _logic;
        private readonly ILogger<ServiceTramiteEliminacion> _logger;
        public ServiceTramiteEliminacion(TramiteLogicEliminacion logic
            , MapeadoresEliminacionTramite mapeadores
            , ValidadoresEliminacionTramite validadores
            , ILogger<ServiceTramiteEliminacion> logger)
        {
            _mapeadores = mapeadores;
            _logic = logic;
            _validadores = validadores;
            _logger = logger;
        }
    }
}
