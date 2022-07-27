using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public partial class MapeadoresLecturaTramite
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

            _tramiteEditViewModel.idtramite = entrada.IdTramite;
            _tramiteEditViewModel.anio = entrada.Anio;
            _tramiteEditViewModel.secuencia = entrada.Secuencia;
            _tramiteEditViewModel.idsector = entrada.IdSector;
            _tramiteEditViewModel.manzana = entrada.Manzana;
            _tramiteEditViewModel.lote = entrada.Lote;
            _tramiteEditViewModel.division = entrada.Division;
            _tramiteEditViewModel.phv = entrada.Phv;
            _tramiteEditViewModel.phh = entrada.Phh;
            _tramiteEditViewModel.numero = entrada.Numero;
            _tramiteEditViewModel.idbeneficiario = entrada.IdBeneficiario;
            _tramiteEditViewModel.nombrebeneficiario = entrada.NombreBeneficiario;
            _tramiteEditViewModel.idtipocontrato = entrada.IdTipoContrato;
            _tramiteEditViewModel.tipocontrato = entrada.TipoContrato;
            _tramiteEditViewModel.areasolar = entrada.AreaSolar;
            _tramiteEditViewModel.aniosplazo = entrada.AniosPlazo;
            _tramiteEditViewModel.idestado = entrada.IdEstado;
            _tramiteEditViewModel.estado = entrada.Estado;
            _tramiteEditViewModel.iddireccion = entrada.IdDireccion;
            _tramiteEditViewModel.direccion = entrada.Direccion;
            _tramiteEditViewModel.aprobacionconcejomun = entrada.AprobacionConcejoMun;
            _tramiteEditViewModel.fechaaprobconcejomun = entrada.FechaAprobConcejoMun;
            _tramiteEditViewModel.fechaescritura = entrada.FechaEscritura;
            _tramiteEditViewModel.fechainsregprop = entrada.FechaInsRegProp;
            _tramiteEditViewModel.oficiorevocatoriamod = entrada.OficioRevocatoriaMod;
            _tramiteEditViewModel.fechainsrevocatoria = entrada.FechaInsRevocatoria;
            _tramiteEditViewModel.observacionjuridico = entrada.ObservacionJuridico;
            _tramiteEditViewModel.baseorigen = entrada.BaseOrigen;
            _tramiteEditViewModel.oficioag = entrada.OficioAg;
            _tramiteEditViewModel.oficiodase = entrada.OficioDase;
            
            salida.dataresult = _tramiteEditViewModel;
        }
    }
}
