
using eMAS.TerrenosComodatos.Domain.Constantes;
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresSeguridad
    {
        private readonly SystemSettings _systemSettings;
        private readonly ILogger<MapeadoresSeguridad> _logger;
        public MapeadoresSeguridad(ILogger<MapeadoresSeguridad> logger
            , SystemSettings systemSettings)
        {
            _systemSettings = systemSettings;
            _logger = logger;
        }
    }
}
