using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionTramiteController : ControllerBase
    {
        private readonly ValidadoresTramitesRequest _validadoresRequest;
        private readonly IServiceTramiteLectura _serviceTramiteLectura;
        public GestionTramiteController(IServiceTramiteLectura serviceTramiteLectura
            , ValidadoresTramitesRequest validadoresRequest)
        {
            _validadoresRequest = validadoresRequest;
            _serviceTramiteLectura = serviceTramiteLectura;
        }
        [HttpGet]
        [Route("ObtenerListadoPorPagina")]
        public ActionResult<ResultadoDTO<DataPagineada<TramitesListViewModel>>> ObtenerListadoPorPagina(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila)
        {
            ResultadoDTO<DataPagineada<TramitesListViewModel>> respuesta = new ResultadoDTO<DataPagineada<TramitesListViewModel>>();

            if (!(_validadoresRequest.ValidaDataRequestLecturaTodosPaginado(panelFilter, resultContainer, numeroPagina, numeroFila, ref respuesta))) 
                return BadRequest(respuesta);
            
            respuesta = _serviceTramiteLectura.ConsultarTramitesTodosPaginado(panelFilter, resultContainer, numeroPagina, numeroFila);

            return Ok(respuesta);
        }
        [HttpGet]
        [Route("ObtenerPorId")]
        public ActionResult<ResultadoDTO<TramiteEditViewModel>> ObteneroPorId(short id)
        {
            ResultadoDTO<TramiteEditViewModel> respuesta = new ResultadoDTO<TramiteEditViewModel>();

            respuesta = _serviceTramiteLectura.ConsultarPorId(id);

            return Ok(respuesta);
        }
        
    }
}
