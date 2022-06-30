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
        private readonly ValidadoresTramitesRequest _validadoresRequest;
        private readonly IServiceTramiteLectura _serviceTramiteLectura;
        public GestionTramiteTopografiaController(IServiceTramiteLectura serviceTramiteLectura
            , ValidadoresTramitesRequest validadoresRequest)
        {
            _validadoresRequest = validadoresRequest;
            _serviceTramiteLectura = serviceTramiteLectura;
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
    }
}
