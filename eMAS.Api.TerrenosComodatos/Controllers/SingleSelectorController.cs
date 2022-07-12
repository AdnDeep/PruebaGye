using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
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
        [HttpGet]
        [Route("GetDataDsr")]
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
