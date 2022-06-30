using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class MapeadoresLecturaTramite
    {
        public void MapearSmcAnexoTramiteEditAAnexoTramiteEditViewModel(ref SmcAnexoTramiteEdit entrada
            , ref ResultadoDTO<AnexoTramiteEditViewModel> salida)
        {
            AnexoTramiteEditViewModel _anexoTramiteEditViewModel = new AnexoTramiteEditViewModel();

            _anexoTramiteEditViewModel.IdAnexoTramite = entrada.IdAnexoTramite;
            _anexoTramiteEditViewModel.IdTramite = entrada.IdTramite;
            _anexoTramiteEditViewModel.Link = entrada.Link;
            _anexoTramiteEditViewModel.PdpEstado = entrada.PdpEstado;
            
            salida.dataresult = _anexoTramiteEditViewModel;
        }

        public void MapearListaAnexoTramiteEditAAnexoTramiteListViewModel(ref List<SmcAnexoTramiteEdit> entrada
            , ref ResultadoDTO<List<AnexoTramiteListViewModel>> salida)
        {
            var lsAnexoTramiteViewModel = new List<AnexoTramiteListViewModel>();
            foreach (var det in entrada)
            {
                lsAnexoTramiteViewModel.Add(new AnexoTramiteListViewModel
                {
                    IdAnexoTramite = det.IdAnexoTramite,
                    IdTramite = det.IdTramite,
                    Link = det.Link,
                    PdpEstado = det.PdpEstado
                });
            }
            salida.dataresult = lsAnexoTramiteViewModel;
        }
    }
}
