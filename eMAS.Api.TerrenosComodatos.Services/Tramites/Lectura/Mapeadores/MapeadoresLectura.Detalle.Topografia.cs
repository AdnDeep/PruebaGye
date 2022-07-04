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
            
            _topografiaTramiteEditViewModel.idtopografiaterreno = entrada.IdTopografiaTerreno;
            _topografiaTramiteEditViewModel.idtipotopografiaterreno = entrada.IdTipoTopografiaTerreno;
            _topografiaTramiteEditViewModel.idtramite = entrada.IdTramite;
            _topografiaTramiteEditViewModel.oficio = entrada.Oficio;
            _topografiaTramiteEditViewModel.fechaenvio = entrada.FechaEnvio;
            _topografiaTramiteEditViewModel.oficiorespuesta = entrada.OficioRespuesta;
            _topografiaTramiteEditViewModel.fecharespuesta = entrada.FechaRespuesta;
            
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
                    idtopografiaterreno = det.IdTopografiaTerreno,
                    idtipoTopografiaterreno = det.IdTipoTopografiaTerreno,
                    idtramite = det.IdTramite,
                    oficio = det.Oficio,
                    fechaenvio = det.FechaEnvio,
                    oficiorespuesta = det.OficioRespuesta,
                    fecharespuesta = det.FechaRespuesta
                });
            }
            salida.dataresult = lsTopografiaTramiteViewModel;
        }
    }
}
