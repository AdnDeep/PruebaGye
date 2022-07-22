
using eMAS.TerrenosComodatos.Domain.Constantes;
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.Extensions.Logging;
using System;

namespace eMAS.TerrenosComodatos.Domain.Application
{
    public partial class MapeadoresTramite
    {
        private readonly SystemSettings _systemSettings;
        private readonly ILogger<MapeadoresTramite> _logger;
        public MapeadoresTramite(ILogger<MapeadoresTramite> logger
            , SystemSettings systemSettings)
        {
            _systemSettings = systemSettings;
            _logger = logger;
        }
        public void GenerateEditViewModelEmpty(ref TramiteEditViewModel model)
        {
            model.idtramite = 0;
        }
        public void GenerateEditViewModelEmptyAnexo(ref AnexoTramiteEditViewModel model) => model.idanexotramite = 0;
        public void GenerateEditViewModelEmptyObservacion(ref ObservacionTramiteEditViewModel model) => model.idtramitedesc = 0;
        public void GenerateEditViewModelEmptyOficio(ref OficioTramiteEditViewModel model) => model.idoficiootrasdirecciones = 0;
        public void GenerateEditViewModelEmptyTopografia(ref TopografiaTerrenoEditViewMoel model) => model.idtopografiaterreno = 0;
        public void GenerateEditViewModel(ref ResultadoDTO<TramiteEditViewModel> model
            , ref ResultadoDTO<TramiteEditViewModel> salida)
        {
            salida.tipo = model.tipo;
            salida.mensaje = model.mensaje;
            salida.dataresult = model.dataresult;
        }
        public void DataLectura(ref ResultadoDTO<TramiteEditViewModel> entrada)
        {
            TramiteEditViewModel tmp = entrada.dataresult;
            tmp.strareasolar = tmp.areasolar != null ? tmp.areasolar.Value.ToString().Replace(",", ".") :"";
            tmp.strfechaaprobconcejomun = tmp.fechaaprobconcejomun != null ? tmp.fechaaprobconcejomun.Value.ToString(AppConst.formatoFechaDefecto) : "";
            tmp.strfechaescritura = tmp.fechaescritura != null ? tmp.fechaescritura.Value.ToString(AppConst.formatoFechaDefecto) : "";
            tmp.strfechainsregprop = tmp.fechainsregprop != null ? tmp.fechainsregprop.Value.ToString(AppConst.formatoFechaDefecto) : "";
            tmp.strfechainsrevocatoria = tmp.fechainsrevocatoria != null ? tmp.fechainsrevocatoria.Value.ToString(AppConst.formatoFechaDefecto) : "";
        }
    }
}
