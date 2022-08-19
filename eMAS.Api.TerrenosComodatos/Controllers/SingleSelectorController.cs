using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ComunLib = eMAS.Api.Comun.Lib;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SingleSelectorController : ControllerBase
    {
        private readonly ValidadoresGenericRequest _validadoresGeneric;
        private readonly IServiceDataProviderGeneric _serviceDataProviderGeneric;
        public SingleSelectorController(IServiceDataProviderGeneric serviceDataProviderGeneric
            , ValidadoresGenericRequest validadoresGeneric)
        {
            _validadoresGeneric = validadoresGeneric;
            _serviceDataProviderGeneric = serviceDataProviderGeneric;
        }
        /// <remarks>
        /// 
        ///     Se utiliza para generar un listado generico de datos con la estructura Key - Value
        /// </remarks>
        /// <param name="key1"></param>
        /// <param name="keyEntity"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDataDsr")]
        [ComunLib.OpenApiExplorerSettings(Flow = ComunLib.OAuthFlow.AuthCodeAAD)]
        public ActionResult<ResultadoDTO<StructKeyValueSelect>> GetDataDsr(string key1, string keyEntity, string target)
        {
            ResultadoDTO<StructKeyValueSelect> respuesta = new ResultadoDTO<StructKeyValueSelect>();

            if (!(_validadoresGeneric.ValidaConsultaDataDsr(key1, target, ref respuesta)))
                return BadRequest(respuesta);

            respuesta = _serviceDataProviderGeneric.GetDataSrc(key1, keyEntity, target);

            return Ok(respuesta);
        }
    }
}
