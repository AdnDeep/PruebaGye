using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class MapeadoresLecturaTramite
    {
        public void MapearSmcObservacionTramiteEditAObservacionTramiteEditViewModel(ref SmcTramitesDescEdit entrada
            , ref ResultadoDTO<ObservacionTramiteEditViewModel> salida)
        {
            ObservacionTramiteEditViewModel _observacionTramiteEditViewModel = new ObservacionTramiteEditViewModel();

            _observacionTramiteEditViewModel.idtramitedesc = entrada.IdTramiteDesc;
            _observacionTramiteEditViewModel.idtramite = entrada.IdTramite;
            _observacionTramiteEditViewModel.fecha = entrada.Fecha;
            _observacionTramiteEditViewModel.observacion = entrada.Observacion;
            
            salida.dataresult = _observacionTramiteEditViewModel;
        }
        public void MapearListaObservacionTramiteEditAObservacionTramiteListViewModel(ref List<SmcTramitesDescEdit> entrada
            , ref ResultadoDTO<List<ObservacionTramiteListViewModel>> salida)
        {
            var lsObservacionTramiteViewModel = new List<ObservacionTramiteListViewModel>();
            foreach (var det in entrada)
            {
                lsObservacionTramiteViewModel.Add(new ObservacionTramiteListViewModel
                {
                    idtramitedesc = det.IdTramiteDesc,
                    idtramite = det.IdTramite,
                    fecha = det.Fecha,
                    observacion = det.Observacion
                });
            }
            salida.dataresult = lsObservacionTramiteViewModel;
        }
    }
}
