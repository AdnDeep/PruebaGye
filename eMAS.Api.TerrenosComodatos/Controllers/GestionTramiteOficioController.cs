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
        private readonly ValidadoresTramitesRequest _validadoresRequest;
        private readonly IServiceTramiteLectura _serviceTramiteLectura;
        public GestionTramiteOficioController(IServiceTramiteLectura serviceTramiteLectura
            , ValidadoresTramitesRequest validadoresRequest)
        {
            _validadoresRequest = validadoresRequest;
            _serviceTramiteLectura = serviceTramiteLectura;
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

    }
}
