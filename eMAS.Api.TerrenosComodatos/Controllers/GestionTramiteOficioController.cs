using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionTramiteOficioController : ControllerBase
    {
        private readonly ValidadoresEliminacionTramite _validadoresEliminacion;
        private readonly ValidadoresEscrituraTramite _validadoresEscritura;
        private readonly IServiceTramiteEliminacion _serviceTramiteEliminacion;
        private readonly IServiceTramiteEscritura _serviceTramiteEscritura;
        private readonly IServiceTramiteLectura _serviceTramiteLectura;
        public GestionTramiteOficioController(IServiceTramiteLectura serviceTramiteLectura
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
        [Route("ObtenerOficioPorId")]
        public ActionResult<ResultadoDTO<OficioTramiteEditViewModel>> ObtenerOficioPorId(short id)
        {
            ResultadoDTO<OficioTramiteEditViewModel> respuesta = new ResultadoDTO<OficioTramiteEditViewModel>();

            respuesta = _serviceTramiteLectura.ConsultarOficioPorId(id);

            return Ok(respuesta);
        }
        [HttpGet]
        [Route("ObtenerOficiosPorIdTramite")]
        public ActionResult<ResultadoDTO<List<OficioTramiteListViewModel>>> ObtenerOficiosPorIdTramite(short id)
        {
            ResultadoDTO<List<OficioTramiteListViewModel>> respuesta = new ResultadoDTO<List<OficioTramiteListViewModel>>();

            respuesta = _serviceTramiteLectura.ConsultarOficiosPorIdTramite(id);

            return Ok(respuesta);
        }
        [HttpPost]
        [Route("Agregar")]
        public ActionResult<ResultadoDTO<int>> Agregar(OficioTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.OficioDataRequestToAdd(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.AgregarOficio(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        [HttpPut]
        [Route("Actualizar")]
        public ActionResult<ResultadoDTO<int>> Actualizar(OficioTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.OficioRequestToUpdate(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.ActualizarOficio(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
        [HttpDelete]
        [Route("Eliminar")]
        public ActionResult<ResultadoDTO<int>> Eliminar(short idOficioTramite, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEliminacion.DataOficioRequestToDelete(idOficioTramite, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEliminacion.EliminarOficio(idOficioTramite, usuario, controlador, pcclient);

            return Ok(respuesta);
        }

    }
}
