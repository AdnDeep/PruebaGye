using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
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
        [HttpGet]
        [Route("ObtenerObservacionPorId")]
        public ActionResult<ResultadoDTO<ObservacionTramiteEditViewModel>> ObtenerObservacionPorId(short id)
        {
            ResultadoDTO<ObservacionTramiteEditViewModel> respuesta = new ResultadoDTO<ObservacionTramiteEditViewModel>();

            respuesta = _serviceTramiteLectura.ConsultarObservacionPorId(id);

            return Ok(respuesta);
        }
        [HttpGet]
        [Route("ObtenerObservacionesPorIdTramite")]
        public ActionResult<ResultadoDTO<List<ObservacionTramiteListViewModel>>> ObtenerObservacionesPorIdTramite(short id)
        {
            ResultadoDTO<List<ObservacionTramiteListViewModel>> respuesta = new ResultadoDTO<List<ObservacionTramiteListViewModel>>();

            respuesta = _serviceTramiteLectura.ConsultarObservacionesPorIdTramite(id);

            return Ok(respuesta);
        }
        [HttpPost]
        [Route("Agregar")]
        public ActionResult<ResultadoDTO<int>> Agregar(ObservacionTramiteEditViewModel model, string usuario, string controlador, string pcclient)
        {
            ResultadoDTO<int> respuesta = new ResultadoDTO<int>();

            if (!(_validadoresEscritura.ObservacionDataRequestToAdd(ref model, usuario, controlador, pcclient, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceTramiteEscritura.AgregarObservacion(model, usuario, controlador, pcclient);

            return Ok(respuesta);
        }
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
