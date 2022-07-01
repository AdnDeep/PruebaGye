using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class MapeadoresLecturaTramite
    {
        public void MapearSmcTopografiaTramiteEditATopografiaTramiteEditViewModel(ref SmcTopografiaTerrenoEdit entrada
            , ref ResultadoDTO<TopografiaTerrenoEditViewMoel> salida)
        {
            TopografiaTerrenoEditViewMoel _topografiaTramiteEditViewModel = new TopografiaTerrenoEditViewMoel();
            
            _topografiaTramiteEditViewModel.IdTopografiaTerreno = entrada.IdTopografiaTerreno;
            _topografiaTramiteEditViewModel.IdTipoTopografiaTerreno = entrada.IdTipoTopografiaTerreno;
            _topografiaTramiteEditViewModel.IdTramite = entrada.IdTramite;
            _topografiaTramiteEditViewModel.Oficio = entrada.Oficio;
            _topografiaTramiteEditViewModel.FechaEnvio = entrada.FechaEnvio;
            _topografiaTramiteEditViewModel.OficioRespuesta = entrada.OficioRespuesta;
            _topografiaTramiteEditViewModel.FechaRespuesta = entrada.FechaRespuesta;
            _topografiaTramiteEditViewModel.PdpEstado = entrada.PdpEstado;
            
            salida.dataresult = _topografiaTramiteEditViewModel;
        }

        public void MapearListaTopografiaTramiteEditATopografiaTramiteListViewModel(ref List<SmcTopografiaTerrenoEdit> entrada
            , ref ResultadoDTO<List<TopografiaTerrenoListViewMoel>> salida)
        {
            var lsTopografiaTramiteViewModel = new List<TopografiaTerrenoListViewMoel>();
            foreach (var det in entrada)
            {
                lsTopografiaTramiteViewModel.Add(new TopografiaTerrenoListViewMoel
                {
                    IdTopografiaTerreno = det.IdTopografiaTerreno,
                    IdTipoTopografiaTerreno = det.IdTipoTopografiaTerreno,
                    IdTramite = det.IdTramite,
                    Oficio = det.Oficio,
                    FechaEnvio = det.FechaEnvio,
                    OficioRespuesta = det.OficioRespuesta,
                    FechaRespuesta = det.FechaRespuesta,
                    PdpEstado = det.PdpEstado,
                });
            }
            salida.dataresult = lsTopografiaTramiteViewModel;
        }
    }
}
