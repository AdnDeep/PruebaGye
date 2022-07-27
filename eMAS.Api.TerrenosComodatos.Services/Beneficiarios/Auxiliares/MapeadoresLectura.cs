using eMAS.Api.TerrenosComodatos.Entities;
using eMAS.Api.TerrenosComodatos.ViewModel;
using System.Collections.Generic;


namespace eMAS.Api.TerrenosComodatos.Services
{
    public class MapeadoresLecturaBeneficiario
    {
        public MapeadoresLecturaBeneficiario()
        { 
        }
        public void MapearModelBeneficiarioEditViewAModelValidacion1(ref BeneficiarioEditViewModel entrada, ref BeneficiariosValidacion1Filter salida)
        {
            salida.Id = entrada.id;
            salida.nombre = entrada.nombre;
        }
        public void MapearSmcBeneficiarioEditABeneficiarioEditViewModel(ref SmcBeneficiarioEdit entrada
            , ref ResultadoDTO<BeneficiarioEditViewModel> salida)
        {
            BeneficiarioEditViewModel _beneficiarioEditViewModel = new BeneficiarioEditViewModel();

            _beneficiarioEditViewModel.id = entrada.IdBeneficiario;
            _beneficiarioEditViewModel.nombre = entrada.Nombre;
            _beneficiarioEditViewModel.representante = entrada.NombreRepresentante;
            _beneficiarioEditViewModel.ruc = entrada.Identificacion;
            _beneficiarioEditViewModel.contacto = entrada.Contacto;
            
            salida.dataresult = _beneficiarioEditViewModel;
        }
        public void MapearListaBeneficiarioPaginadaAListaBeneficiarioViewModel(ref List<SmcBeneficiarioPaginado> entrada
            , ref ResultadoDTO<DataPagineada<BeneficiariosListViewModel>> salida
            , int numeroPagina, int totalpaginas, string resultContainer)
        {
            DataPagineada<BeneficiariosListViewModel> dataPaged = new DataPagineada<BeneficiariosListViewModel>();
            
            dataPaged.paginaactual = numeroPagina;
            dataPaged.totalpaginas = totalpaginas;
            dataPaged.resultcontainer = resultContainer;
            var lsBeneficiarioViewModel = new List<BeneficiariosListViewModel>();
            foreach (var det in entrada)
            {
                lsBeneficiarioViewModel.Add(new BeneficiariosListViewModel
                {
                    id = det.IdBeneficiario,
                    nombre = det.Nombre,
                    contacto = det.Contacto,
                    representante = det.NombreRepresentante,
                    ruc = det.Identificacion
                });
            }
            dataPaged.data = lsBeneficiarioViewModel;
            salida.dataresult = dataPaged;
        }
    }
}
