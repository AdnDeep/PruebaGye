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
        private readonly ValidadoresTramitesRequest _validadoresRequest;
        private readonly IServiceTramiteLectura _serviceTramiteLectura;
        public GestionTramiteObservacionController(IServiceTramiteLectura serviceTramiteLectura
            , ValidadoresTramitesRequest validadoresRequest)
        {
            _validadoresRequest = validadoresRequest;
            _serviceTramiteLectura = serviceTramiteLectura;
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

    }
}
