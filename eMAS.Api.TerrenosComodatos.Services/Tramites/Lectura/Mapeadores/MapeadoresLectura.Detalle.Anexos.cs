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

            _anexoTramiteEditViewModel.idanexotramite = entrada.IdAnexoTramite;
            _anexoTramiteEditViewModel.idtramite = entrada.IdTramite;
            _anexoTramiteEditViewModel.link = entrada.Link;
            
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
                    idanexotramite = det.IdAnexoTramite,
                    idtramite = det.IdTramite,
                    link = det.Link
                });
            }
            salida.dataresult = lsAnexoTramiteViewModel;
        }
    }
}
