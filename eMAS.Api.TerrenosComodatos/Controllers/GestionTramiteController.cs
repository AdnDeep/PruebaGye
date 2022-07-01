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
        private readonly ValidadoresEliminacionTramite _validadoresEliminacion;
        private readonly ValidadoresEscrituraTramite _validadoresEscritura;
        private readonly ValidadoresTramitesRequest _validadoresRequest;
        private readonly IServiceTramiteEliminacion _serviceTramiteEliminacion;
        private readonly IServiceTramiteEscritura _serviceTramiteEscritura;
        private readonly IServiceTramiteLectura _serviceTramiteLectura;
        public GestionTramiteController(IServiceTramiteLectura serviceTramiteLectura
            , IServiceTramiteEscritura serviceTramiteEscritura
            , IServiceTramiteEliminacion serviceTramiteEliminacion
            , ValidadoresEliminacionTramite validadoresEliminacion
            , ValidadoresEscrituraTramite validadoresEscritura
            , ValidadoresTramitesRequest validadoresRequest)
        {
            _validadoresEliminacion = validadoresEliminacion;
            _validadoresRequest = validadoresRequest;
            _validadoresEscritura = validadoresEscritura;
            _serviceTramiteLectura = serviceTramiteLectura;
            _serviceTramiteEscritura = serviceTramiteEscritura;
            _serviceTramiteEliminacion = serviceTramiteEliminacion;
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
        [HttpPost]
        [Route("Agregar")]
        public ActionResult<ResultadoDTO<int>> Agregar(TramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.DataRequestToAdd(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.Agregar(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        [HttpPut]
        [Route("Actualizar")]
        public ActionResult<ResultadoDTO<int>> Actualizar(TramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.DataRequestToUpdate(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.Actualizar(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        [HttpDelete]
        [Route("Eliminar")]
        public ActionResult<ResultadoDTO<int>> Eliminar(short idTramite, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEliminacion.DataRequestToDelete(idTramite, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEliminacion.Eliminar(idTramite, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
    }
}
