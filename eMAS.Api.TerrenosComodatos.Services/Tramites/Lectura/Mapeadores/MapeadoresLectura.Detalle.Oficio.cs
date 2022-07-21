using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class MapeadoresLecturaTramite
    {
        public void MapearSmcOficioTramiteEditAOficioTramiteEditViewModel(ref SmcOficioOtrasDireccioneEdit entrada
            , ref ResultadoDTO<OficioTramiteEditViewModel> salida)
        {
            OficioTramiteEditViewModel _oficioTramiteEditViewModel = new OficioTramiteEditViewModel();
            
            _oficioTramiteEditViewModel.idoficiootrasdirecciones = entrada.IdOficioOtrasDirecciones;
            _oficioTramiteEditViewModel.idtramite = entrada.IdTramite;
            _oficioTramiteEditViewModel.secuencia = entrada.Secuencia;
            _oficioTramiteEditViewModel.iddireccion = entrada.IdDireccion;
            _oficioTramiteEditViewModel.oficio = entrada.Oficio;
            _oficioTramiteEditViewModel.fechaenvio = entrada.FechaEnvio;
            _oficioTramiteEditViewModel.oficiorespuesta = entrada.OficioRespuesta;
            _oficioTramiteEditViewModel.fecharespuesta = entrada.FechaRespuesta;
            
            salida.dataresult = _oficioTramiteEditViewModel;
        }

        public void MapearListaOficioTramiteEditAOficioTramiteListViewModel(ref List<SmcOficioOtrasDireccioneEdit> entrada
            , ref ResultadoDTO<List<OficioTramiteListViewModel>> salida)
        {
            var lsOficioTramiteViewModel = new List<OficioTramiteListViewModel>();
            foreach (var det in entrada)
            {
                lsOficioTramiteViewModel.Add(new OficioTramiteListViewModel
                {
                    idoficiootrasdirecciones = det.IdOficioOtrasDirecciones,
                    idtramite = det.IdTramite,
                    secuencia = det.Secuencia,
                    iddireccion = det.IdDireccion,
                    direccion = det.Direccion,
                    oficio = det.Oficio,
                    fechaenvio = det.FechaEnvio,
                    oficiorespuesta = det.OficioRespuesta,
                    fecharespuesta = det.FechaRespuesta
                });
            }
            salida.dataresult = lsOficioTramiteViewModel;
        }
    }
}
