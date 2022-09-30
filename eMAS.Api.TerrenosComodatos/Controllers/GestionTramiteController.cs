using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using ComunLib = eMAS.Api.Comun.Lib;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GestionTramiteController : DefaultController
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
            , ValidadoresTramitesRequest validadoresRequest
            , IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _validadoresEliminacion = validadoresEliminacion;
            _validadoresRequest = validadoresRequest;
            _validadoresEscritura = validadoresEscritura;
            _serviceTramiteLectura = serviceTramiteLectura;
            _serviceTramiteEscritura = serviceTramiteEscritura;
            _serviceTramiteEliminacion = serviceTramiteEliminacion;
        }
        /// <remarks>
        /// 
        ///     Se obtiene listado por pagina
        /// </remarks>
        /// <param name="panelFilter"></param>
        /// <param name="resultContainer"></param>
        /// <param name="numeroPagina"></param>
        /// <param name="numeroFila"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerListadoPorPagina")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<DataPagineada<TramitesListViewModel>>> ObtenerListadoPorPagina(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila)
        {
            ResultadoDTO<DataPagineada<TramitesListViewModel>> respuesta = new ResultadoDTO<DataPagineada<TramitesListViewModel>>();

            if (!(_validadoresRequest.ValidaDataRequestLecturaTodosPaginado(panelFilter, resultContainer, numeroPagina, numeroFila, ref respuesta))) 
                return BadRequest(respuesta);
            
            respuesta = _serviceTramiteLectura.ConsultarTramitesTodosPaginado(panelFilter, resultContainer, numeroPagina, numeroFila);

            return Ok(respuesta);
        }
        /// <remarks>
        /// 
        ///     Se obtiene un registro por id
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerPorId")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<TramiteEditViewModel>> ObtenerPorId(short id)
        {
            ResultadoDTO<TramiteEditViewModel> respuesta = new ResultadoDTO<TramiteEditViewModel>();

            respuesta = _serviceTramiteLectura.ConsultarPorId(id);

            return Ok(respuesta);
        }
        /// <remarks>
        /// 
        ///     Se utiliza para agregar
        /// </remarks>
        /// <param name="model"></param>
        /// <param name="usuario"></param>
        /// <param name="controlador"></param>
        /// <param name="pcclient"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Agregar")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<int>> Agregar(TramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.DataRequestToAdd(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.Agregar(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        /// <remarks>
        /// 
        ///     Se utiliza para actualizar
        /// </remarks>
        /// <param name="model"></param>
        /// <param name="usuario"></param>
        /// <param name="controlador"></param>
        /// <param name="pcclient"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Actualizar")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<int>> Actualizar(TramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.DataRequestToUpdate(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.Actualizar(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        /// <remarks>
        /// 
        ///     Se utiliza para eliminar
        /// </remarks>
        /// <param name="idTramite"></param>
        /// <param name="usuario"></param>
        /// <param name="controlador"></param>
        /// <param name="pcclient"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Eliminar")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
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
