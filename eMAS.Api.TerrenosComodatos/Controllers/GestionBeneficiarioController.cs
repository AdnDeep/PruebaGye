using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ComunLib = eMAS.Api.Comun.Lib;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GestionBeneficiarioController : ControllerBase
    {
        private readonly ValidadoresBeneficiariosRequest _validadoresRequest;
        private readonly IServiceBeneficiarioEscritura _serviceBeneficiarioEscritura;
        private readonly IServiceBeneficiarioLecturaTodos _serviceBeneficiarioLecturaTodos;
        private readonly IServiceBeneficiarioEliminacion _serviceBeneficiarioEliminacion;
        public GestionBeneficiarioController(IServiceBeneficiarioLecturaTodos serviceBeneficiarioLecturaTodos
            , IServiceBeneficiarioEscritura serviceBeneficiarioEscritura
            , IServiceBeneficiarioEliminacion serviceBeneficiarioEliminacion
            , ValidadoresBeneficiariosRequest validadoresRequest)
        {
            _validadoresRequest = validadoresRequest;
            _serviceBeneficiarioLecturaTodos = serviceBeneficiarioLecturaTodos;
            _serviceBeneficiarioEscritura = serviceBeneficiarioEscritura;
            _serviceBeneficiarioEliminacion = serviceBeneficiarioEliminacion;
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

        public ActionResult<ResultadoDTO<DataPagineada<BeneficiariosListViewModel>>> ObtenerListadoPorPagina(string panelFilter
            , string resultContainer, int numeroPagina, int numeroFila)
        {
            ResultadoDTO<DataPagineada<BeneficiariosListViewModel>> respuesta = new ResultadoDTO<DataPagineada<BeneficiariosListViewModel>>();

            if (!(_validadoresRequest.ValidaDataRequestLecturaTodosPaginado(panelFilter, resultContainer, numeroPagina, numeroFila, ref respuesta))) 
                return BadRequest(respuesta);
            
            respuesta = _serviceBeneficiarioLecturaTodos.ConsultarBeneficiariosTodosPaginado(panelFilter, resultContainer, numeroPagina, numeroFila);

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
        public ActionResult<ResultadoDTO<BeneficiarioEditViewModel>> ObteneroPorId(short id)
        {
            ResultadoDTO<BeneficiarioEditViewModel> respuesta = new ResultadoDTO<BeneficiarioEditViewModel>();

            respuesta = _serviceBeneficiarioLecturaTodos.ConsultarPorId(id);

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
        public ActionResult<ResultadoDTO<BeneficiarioEditViewModel>> Agregar(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<BeneficiarioEditViewModel> respuesta = new ResultadoDTO<BeneficiarioEditViewModel>();

            if (!(_validadoresRequest.ValidarDatosClienteBeneficiarioEditViewModel(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceBeneficiarioEscritura.Agregar(model, usuario, controlador, pcclient);

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
        public ActionResult<ResultadoDTO<BeneficiarioEditViewModel>> Actualizar(BeneficiarioEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<BeneficiarioEditViewModel> respuesta = new ResultadoDTO<BeneficiarioEditViewModel>();

            if (!(_validadoresRequest.ValidarDatosClienteBeneficiarioEditViewModel(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceBeneficiarioEscritura.Actualizar(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        /// <remarks>
        /// 
        ///     Se utiliza para eliminar.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <param name="controlador"></param>
        /// <param name="pcclient"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Eliminar")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<BeneficiarioEditViewModel>> Eliminar(short id, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<string> respuesta = new ResultadoDTO<string>();

            if (!(_validadoresRequest.ValidarDatosEliminacionClienteBeneficiario(id, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceBeneficiarioEliminacion.Eliminar(id, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
    }
}
