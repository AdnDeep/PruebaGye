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
            
            _oficioTramiteEditViewModel.IdOficioOtrasDirecciones = entrada.IdOficioOtrasDirecciones;
            _oficioTramiteEditViewModel.IdTramite = entrada.IdTramite;
            _oficioTramiteEditViewModel.Secuencia = entrada.Secuencia;
            _oficioTramiteEditViewModel.IdDireccion = entrada.IdDireccion;
            _oficioTramiteEditViewModel.Oficio = entrada.Oficio;
            _oficioTramiteEditViewModel.FechaEnvio = entrada.FechaEnvio;
            _oficioTramiteEditViewModel.OficioRespuesta = entrada.OficioRespuesta;
            _oficioTramiteEditViewModel.FechaRespuesta = entrada.FechaRespuesta;
            _oficioTramiteEditViewModel.PdpEstado = entrada.PdpEstado;
            
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
                    IdOficioOtrasDirecciones = det.IdOficioOtrasDirecciones,
                    IdTramite = det.IdTramite,
                    Secuencia = det.Secuencia,
                    IdDireccion = det.IdDireccion,
                    Oficio = det.Oficio,
                    FechaEnvio = det.FechaEnvio,
                    OficioRespuesta = det.OficioRespuesta,
                    FechaRespuesta = det.FechaRespuesta,
                    PdpEstado = det.PdpEstado
                });
            }
            salida.dataresult = lsOficioTramiteViewModel;
        }
    }
}
