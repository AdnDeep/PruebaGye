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
    public class GestionTramiteTopografiaController : ControllerBase
    {
        private readonly ValidadoresEliminacionTramite _validadoresEliminacion;
        private readonly ValidadoresEscrituraTramite _validadoresEscritura;
        private readonly IServiceTramiteEliminacion _serviceTramiteEliminacion;
        private readonly IServiceTramiteEscritura _serviceTramiteEscritura;
        private readonly IServiceTramiteLectura _serviceTramiteLectura;
        public GestionTramiteTopografiaController(IServiceTramiteLectura serviceTramiteLectura
            , ValidadoresEliminacionTramite validadoresEliminacion
            , ValidadoresEscrituraTramite validadoresEscritura
            , IServiceTramiteEliminacion serviceTramiteEliminacion
            , IServiceTramiteEscritura serviceTramiteEscritura)
        {
            _serviceTramiteLectura = serviceTramiteLectura;
            _serviceTramiteEscritura = serviceTramiteEscritura;
            _serviceTramiteEliminacion = serviceTramiteEliminacion;
            _validadoresEscritura = validadoresEscritura;
            _validadoresEliminacion = validadoresEliminacion;
        }
        /// <remarks>
        /// 
        ///     Se utiliza para obtener un registro por id
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerTopografiaPorId")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<TopografiaTerrenoEditViewMoel>> ObtenerTopografiaPorId(short id)
        {
            ResultadoDTO<TopografiaTerrenoEditViewMoel> respuesta = new ResultadoDTO<TopografiaTerrenoEditViewMoel>();

            respuesta = _serviceTramiteLectura.ConsultarTopografiaPorId(id);

            return Ok(respuesta);
        }
        /// <remarks>
        /// 
        ///     Obtiene un listado pr Id de tabla cabecera de Trámite
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerTopografiasPorIdTramite")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<List<TopografiaTerrenoListViewMoel>>> ObtenerTopografiasPorIdTramite(short id)
        {
            ResultadoDTO<List<TopografiaTerrenoListViewMoel>> respuesta = new ResultadoDTO<List<TopografiaTerrenoListViewMoel>>();

            respuesta = _serviceTramiteLectura.ConsultarTopografiasPorIdTramite(id);

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
        public ActionResult<ResultadoDTO<int>> Agregar(TopografiaTerrenoEditViewMoel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.TopografiaDataRequestToAdd(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.AgregarTopografia(model, usuario, controlador, pcclient);

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
        public ActionResult<ResultadoDTO<int>> Actualizar(TopografiaTerrenoEditViewMoel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.TopografiaRequestToUpdate(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.ActualizarTopografia(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        /// <remarks>
        /// 
        ///     Se utiliza para eliminar
        /// </remarks>
        /// <param name="idTopografiaTramite"></param>
        /// <param name="usuario"></param>
        /// <param name="controlador"></param>
        /// <param name="pcclient"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Eliminar")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<int>> Eliminar(short idTopografiaTramite, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEliminacion.DataTopografiaRequestToDelete(idTopografiaTramite, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEliminacion.EliminarTopografia(idTopografiaTramite, usuario, controlador, pcclient);

            return Ok(respuesta);
        }

    }
}
