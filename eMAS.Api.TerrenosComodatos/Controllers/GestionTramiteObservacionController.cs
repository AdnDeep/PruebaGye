using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ComunLib = eMAS.Api.Comun.Lib;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GestionTramiteObservacionController : ControllerBase
    {
        private readonly ValidadoresEliminacionTramite _validadoresEliminacion;
        private readonly ValidadoresEscrituraTramite _validadoresEscritura;
        private readonly IServiceTramiteEliminacion _serviceTramiteEliminacion;
        private readonly IServiceTramiteEscritura _serviceTramiteEscritura;
        private readonly IServiceTramiteLectura _serviceTramiteLectura;

        public GestionTramiteObservacionController(IServiceTramiteLectura serviceTramiteLectura
            , ValidadoresEliminacionTramite validadoresEliminacion
            , ValidadoresEscrituraTramite validadoresEscritura
            , IServiceTramiteEliminacion serviceTramiteEliminacion
            , IServiceTramiteEscritura serviceTramiteEscritura
            )
        {
            _serviceTramiteLectura = serviceTramiteLectura;

            _serviceTramiteEscritura = serviceTramiteEscritura;
            _serviceTramiteEliminacion = serviceTramiteEliminacion;
            _validadoresEscritura = validadoresEscritura;
            _validadoresEliminacion = validadoresEliminacion;
        }
        /// <remarks>
        /// 
        ///     Se utiliza para obtener por Id
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerObservacionPorId")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<ObservacionTramiteEditViewModel>> ObtenerObservacionPorId(short id)
        {
            ResultadoDTO<ObservacionTramiteEditViewModel> respuesta = new ResultadoDTO<ObservacionTramiteEditViewModel>();

            respuesta = _serviceTramiteLectura.ConsultarObservacionPorId(id);

            return Ok(respuesta);
        }
        /// <remarks>
        /// 
        ///     Obtiene un listado pr Id de tabla cabecera de Trámite
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerObservacionesPorIdTramite")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<List<ObservacionTramiteListViewModel>>> ObtenerObservacionesPorIdTramite(short id)
        {
            ResultadoDTO<List<ObservacionTramiteListViewModel>> respuesta = new ResultadoDTO<List<ObservacionTramiteListViewModel>>();

            respuesta = _serviceTramiteLectura.ConsultarObservacionesPorIdTramite(id);

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
        public ActionResult<ResultadoDTO<int>> Agregar(ObservacionTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.ObservacionDataRequestToAdd(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.AgregarObservacion(model, usuario, controlador, pcclient);

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
        public ActionResult<ResultadoDTO<int>> Actualizar(ObservacionTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.ObservacionRequestToUpdate(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.ActualizarObservacion(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        /// <remarks>
        /// 
        ///     Se utiliza para eliminar
        /// </remarks>
        /// <param name="idObservacionTramite"></param>
        /// <param name="usuario"></param>
        /// <param name="controlador"></param>
        /// <param name="pcclient"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Eliminar")]
        public ActionResult<ResultadoDTO<int>> Eliminar(short idObservacionTramite, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEliminacion.DataObservacionRequestToDelete(idObservacionTramite, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEliminacion.EliminarObservacion(idObservacionTramite, usuario, controlador, pcclient);

            return Ok(respuesta);
        }

    }
}
