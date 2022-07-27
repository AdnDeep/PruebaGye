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
    public partial class ServiceTramiteEscritura : IServiceTramiteEscritura
    {
        private const string objValidadotEscrituraTramiteTopografia = "SmcPr_SmcTopografiaTerreno_GetDataValidationTramiteTopografiaEscritura";
        private const string objValidadotEscrituraTramiteObservacion = "SmcPr_SmcTramitesDescs_GetDataValidationTramiteObservacionEscritura";
        private const string objValidadotEscrituraTramiteOficio = "SmcPr_SmcOficioOtrasDirecciones_GetDataValidationTramiteOficioEscritura";
        private const string objValidadotEscrituraTramiteAnexo = "SmcPr_SmcAnexoTramite_GetDataValidationTramiteAnexoEscritura";
        private const string objValidadotEscrituraTramite = "SmcPr_SmcTramites_GetDataValidationTramiteEscritura";

        private readonly MapeadoresEscrituraTramite _mapeadores;
        private readonly ValidadoresEscrituraTramite _validadores;
        private readonly TramiteLogicEscritura _logic;
        private readonly ILogger<ServiceTramiteEscritura> _logger;
        public ServiceTramiteEscritura(TramiteLogicEscritura     logic
            , MapeadoresEscrituraTramite mapeadores
            , ValidadoresEscrituraTramite validadores
            , ILogger<ServiceTramiteEscritura> logger)
        {
            _mapeadores = mapeadores;
            _logic = logic;
            _validadores = validadores;
            _logger = logger;
        }
    }
}
