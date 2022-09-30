using eMAS.Api.TerrenosComodatos.Extensions;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;
using ComunLib = eMAS.Api.Comun.Lib;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly ValidadoresGeneric _validadores;
        private readonly ValidadoresGenericRequest _validadoresRequest;
        private readonly IServiceDataProviderGeneric _serviceDataProviderGeneric;
        private readonly ILogger<ExportController> _logger;
        public ExportController(
            IServiceDataProviderGeneric serviceDataProviderGeneric
            , ValidadoresGenericRequest validadoresRequest
            , ValidadoresGeneric validadores
            , ILogger<ExportController> logger
            )
        {
            _validadores = validadores;
            _validadoresRequest = validadoresRequest;
            _serviceDataProviderGeneric = serviceDataProviderGeneric;
            _logger = logger;
        }
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="codigo"></param>
        /// <param name="paramsFilter"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSingleGenericData")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public async Task<IActionResult> GetSingleGenericData(string codigo, string paramsFilter)
        {
            ResultadoDTO<ExportSingleResult> respuesta = new ResultadoDTO<ExportSingleResult>();

            if (!(_validadoresRequest.ValidaConsultaDataExport(codigo, paramsFilter, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceDataProviderGeneric.GetDataExport(codigo, paramsFilter);

            if (respuesta.dataresult.codigoestado == 500)
                return StatusCode(500, respuesta);
            else if (respuesta.dataresult.codigoestado == 204)
                return StatusCode(204, respuesta);

            return Ok(respuesta);
        }
    }
}
