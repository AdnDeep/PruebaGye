using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
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
        [HttpGet]
        [Route("ObtenerTopografiaPorId")]
        public ActionResult<ResultadoDTO<TopografiaTerrenoEditViewMoel>> ObtenerTopografiaPorId(short id)
        {
            ResultadoDTO<TopografiaTerrenoEditViewMoel> respuesta = new ResultadoDTO<TopografiaTerrenoEditViewMoel>();

            respuesta = _serviceTramiteLectura.ConsultarTopografiaPorId(id);

            return Ok(respuesta);
        }
        [HttpGet]
        [Route("ObtenerTopografiasPorIdTramite")]
        public ActionResult<ResultadoDTO<List<TopografiaTerrenoListViewMoel>>> ObtenerTopografiasPorIdTramite(short id)
        {
            ResultadoDTO<List<TopografiaTerrenoListViewMoel>> respuesta = new ResultadoDTO<List<TopografiaTerrenoListViewMoel>>();

            respuesta = _serviceTramiteLectura.ConsultarTopografiasPorIdTramite(id);

            return Ok(respuesta);
        }
        [HttpPost]
        [Route("Agregar")]
        public ActionResult<ResultadoDTO<int>> Agregar(TopografiaTerrenoEditViewMoel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.TopografiaDataRequestToAdd(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.AgregarTopografia(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        [HttpPut]
        [Route("Actualizar")]
        public ActionResult<ResultadoDTO<int>> Actualizar(TopografiaTerrenoEditViewMoel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.TopografiaRequestToUpdate(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.ActualizarTopografia(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        [HttpDelete]
        [Route("Eliminar")]
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
