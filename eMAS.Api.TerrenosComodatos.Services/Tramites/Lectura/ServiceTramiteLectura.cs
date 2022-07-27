using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Logic;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class ServiceTramiteLectura : IServiceTramiteLectura
    {
        private readonly MapeadoresLecturaTramite _mapeadoresLectura;
        private readonly ValidadoresLecturaTramite _validadoresTramites;
        private readonly TramiteLogicLectura _tramiteLogicLectura;
        private readonly ILogger<ServiceTramiteLectura> _logger;
        public ServiceTramiteLectura(TramiteLogicLectura tramiteLogicLectura
            , MapeadoresLecturaTramite mapeadoresLectura
            , ValidadoresLecturaTramite validadoresTramites
            , ILogger<ServiceTramiteLectura> logger)
        {
            _mapeadoresLectura = mapeadoresLectura;
            _tramiteLogicLectura = tramiteLogicLectura;
            _validadoresTramites = validadoresTramites;
            _logger = logger;
        }
    }
}
