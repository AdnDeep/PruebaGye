using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionTramiteAnexoController : ControllerBase
    {
        private readonly ValidadoresTramitesRequest _validadoresRequest;
        private readonly IServiceTramiteLectura _serviceTramiteLectura;
        public GestionTramiteAnexoController(IServiceTramiteLectura serviceTramiteLectura
            , ValidadoresTramitesRequest validadoresRequest)
        {
            _validadoresRequest = validadoresRequest;
            _serviceTramiteLectura = serviceTramiteLectura;
        }
        [HttpGet]
        [Route("ObtenerAnexoPorId")]
        public ActionResult<ResultadoDTO<AnexoTramiteEditViewModel>> ObtenerAnexoPorId(short id)
        {
            ResultadoDTO<AnexoTramiteEditViewModel> respuesta = new ResultadoDTO<AnexoTramiteEditViewModel>();

            respuesta = _serviceTramiteLectura.ConsultarAnexoPorId(id);

            return Ok(respuesta);
        }
        [HttpGet]
        [Route("ObtenerAnexosPorIdTramite")]
        public ActionResult<ResultadoDTO<List<AnexoTramiteListViewModel>>> ObtenerAnexosPorIdTramite(short id)
        {
            ResultadoDTO<List<AnexoTramiteListViewModel>> respuesta = new ResultadoDTO<List<AnexoTramiteListViewModel>>();

            respuesta = _serviceTramiteLectura.ConsultarAnexosPorIdTramite(id);

            return Ok(respuesta);
        }        
    }
}
