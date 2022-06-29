using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public class MapeadoresLecturaTramite
    {
        public MapeadoresLecturaTramite()
        { 
        }
        public void MapearListaTramitePaginadaAListaTramiteViewModel(ref List<SmcTramitePaginado> entrada
            , ref ResultadoDTO<DataPagineada<TramitesListViewModel>> salida
            , int numeroPagina, int totalpaginas, string resultContainer)
        {
            DataPagineada<TramitesListViewModel> dataPaged = new DataPagineada<TramitesListViewModel>();

            dataPaged.paginaactual = numeroPagina;
            dataPaged.totalpaginas = totalpaginas;
            dataPaged.resultcontainer = resultContainer;
            var lsTramiteViewModel = new List<TramitesListViewModel>();
            foreach (var det in entrada)
            {
                string codigoCatastral = $"{det.IdSector}-{det.Manzana}-{det.Lote}-{det.Division}-{det.Phv}-{det.Phh}-{det.Numero}";
                lsTramiteViewModel.Add(new TramitesListViewModel
                {
                    id = det.IdTramite,
                    anioexp = det.Anio,
                    secexp = det.Secuencia,
                    beneficiario= det.NombreBeneficiario,
                    ruc = det.Identificacion,
                    codigocatastral = codigoCatastral
                });
            }
            dataPaged.data = lsTramiteViewModel;
            salida.dataresult = dataPaged;
        }
        public void MapearSmcTramiteEditATramiteEditViewModel(ref SmcTramiteEdit entrada
            , ref ResultadoDTO<TramiteEditViewModel> salida)
        {
            TramiteEditViewModel _tramiteEditViewModel = new TramiteEditViewModel();

            _tramiteEditViewModel.IdTramite = entrada.IdTramite;
            _tramiteEditViewModel.Anio = entrada.Anio;
            _tramiteEditViewModel.Secuencia = entrada.Secuencia;
            _tramiteEditViewModel.IdSector = entrada.IdSector;
            _tramiteEditViewModel.Manzana = entrada.Manzana;
            _tramiteEditViewModel.Lote = entrada.Lote;
            _tramiteEditViewModel.Division = entrada.Division;
            _tramiteEditViewModel.Phv = entrada.Phv;
            _tramiteEditViewModel.Phh = entrada.Phh;
            _tramiteEditViewModel.Numero = entrada.Numero;
            _tramiteEditViewModel.IdBeneficiario = entrada.IdBeneficiario;
            _tramiteEditViewModel.NombreBeneficiario = entrada.NombreBeneficiario;
            _tramiteEditViewModel.IdTipoContrato = entrada.IdTipoContrato;
            _tramiteEditViewModel.TipoContrato = entrada.TipoContrato;
            _tramiteEditViewModel.AreaSolar = entrada.AreaSolar;
            _tramiteEditViewModel.AniosPlazo = entrada.AniosPlazo;
            _tramiteEditViewModel.IdEstado = entrada.IdEstado;
            _tramiteEditViewModel.Estado = entrada.Estado;
            _tramiteEditViewModel.IdDireccion = entrada.IdDireccion;
            _tramiteEditViewModel.Direccion = entrada.Direccion;
            _tramiteEditViewModel.AprobacionConcejoMun = entrada.AprobacionConcejoMun;
            _tramiteEditViewModel.FechaAprobConcejoMun = entrada.FechaAprobConcejoMun;
            _tramiteEditViewModel.FechaEscritura = entrada.FechaEscritura;
            _tramiteEditViewModel.FechaInsRegProp = entrada.FechaInsRegProp;
            _tramiteEditViewModel.OficioRevocatoriaMod = entrada.OficioRevocatoriaMod;
            _tramiteEditViewModel.FechaInsRevocatoria = entrada.FechaInsRevocatoria;
            _tramiteEditViewModel.ObservacionJuridico = entrada.ObservacionJuridico;
            _tramiteEditViewModel.BaseOrigen = entrada.BaseOrigen;
            _tramiteEditViewModel.OficioAg = entrada.OficioAg;
            _tramiteEditViewModel.OficioDase = entrada.OficioDase;
            _tramiteEditViewModel.PdpEstado = entrada.PdpEstado;

            salida.dataresult = _tramiteEditViewModel;
        }
    }
}
