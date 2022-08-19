﻿using eMAS.Api.TerrenosComodatos.IServices;
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
    public class GestionTramiteAnexoController : ControllerBase
    {
        private readonly IServiceTramiteEscritura _serviceTramiteEscritura;
        private readonly IServiceTramiteEliminacion _serviceTramiteEliminacion;
        private readonly ValidadoresEliminacionTramite _validadoresEliminacion;
        private readonly ValidadoresEscrituraTramite _validadoresEscritura;
        private readonly IServiceTramiteLectura _serviceTramiteLectura;
        
        public GestionTramiteAnexoController(IServiceTramiteLectura serviceTramiteLectura
            , IServiceTramiteEscritura serviceTramiteEscritura
            , IServiceTramiteEliminacion serviceTramiteEliminacion
            , ValidadoresEliminacionTramite validadoresEliminacion
            , ValidadoresEscrituraTramite validadoresEscritura)
        {
            _serviceTramiteEscritura = serviceTramiteEscritura;
            _serviceTramiteEliminacion = serviceTramiteEliminacion;

            _validadoresEliminacion = validadoresEliminacion;
            _validadoresEscritura = validadoresEscritura;

            _serviceTramiteLectura = serviceTramiteLectura;
        }
        /// <remarks>
        /// 
        ///     Se obtiene un registro por id
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerAnexoPorId")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<AnexoTramiteEditViewModel>> ObtenerAnexoPorId(short id)
        {
            ResultadoDTO<AnexoTramiteEditViewModel> respuesta = new ResultadoDTO<AnexoTramiteEditViewModel>();

            respuesta = _serviceTramiteLectura.ConsultarAnexoPorId(id);

            return Ok(respuesta);
        }
        /// <remarks>
        /// 
        ///     Obtiene un listado pr Id de tabla cabecera de Trámite
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObtenerAnexosPorIdTramite")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<List<AnexoTramiteListViewModel>>> ObtenerAnexosPorIdTramite(short id)
        {
            ResultadoDTO<List<AnexoTramiteListViewModel>> respuesta = new ResultadoDTO<List<AnexoTramiteListViewModel>>();

            respuesta = _serviceTramiteLectura.ConsultarAnexosPorIdTramite(id);

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
        public ActionResult<ResultadoDTO<int>> Agregar(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.AnexoDataRequestToAdd(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.AgregarAnexo(model, usuario, controlador, pcclient);

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
        public ActionResult<ResultadoDTO<int>> Actualizar(AnexoTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.AnexoRequestToUpdate(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.ActualizarAnexo(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        /// <remarks>
        /// 
        ///     Se utiliza para eliminar
        /// </remarks>
        /// <param name="idAnexoTramite"></param>
        /// <param name="usuario"></param>
        /// <param name="controlador"></param>
        /// <param name="pcclient"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Eliminar")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<int>> Eliminar(short idAnexoTramite, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEliminacion.DataAnexoRequestToDelete(idAnexoTramite, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEliminacion.EliminarAnexo(idAnexoTramite, usuario, controlador, pcclient);

            return Ok(respuesta);
        }

    }
}
