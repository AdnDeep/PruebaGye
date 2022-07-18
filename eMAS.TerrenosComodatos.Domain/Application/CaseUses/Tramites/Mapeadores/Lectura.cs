
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
        public void GenerateEditViewModel(ref ResultadoDTO<TramiteEditViewModel> model
            , ref ResultadoDTO<TramiteEditViewModel> salida)
        {
            salida.tipo = model.tipo;
            salida.mensaje = model.mensaje;
            salida.dataresult = model.dataresult;
        }
    }
}
