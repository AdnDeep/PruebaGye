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

            _observacionTramiteEditViewModel.IdTramiteDesc = entrada.IdTramiteDesc;
            _observacionTramiteEditViewModel.IdTramite = entrada.IdTramite;
            _observacionTramiteEditViewModel.Fecha = entrada.Fecha;
            _observacionTramiteEditViewModel.Observacion = entrada.Observacion;
            _observacionTramiteEditViewModel.PdpEstado = entrada.PdpEstado;

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
                    IdTramiteDesc = det.IdTramiteDesc,
                    IdTramite = det.IdTramite,
                    Fecha = det.Fecha,
                    Observacion = det.Observacion,
                    PdpEstado = det.PdpEstado
                });
            }
            salida.dataresult = lsObservacionTramiteViewModel;
        }
    }
}
