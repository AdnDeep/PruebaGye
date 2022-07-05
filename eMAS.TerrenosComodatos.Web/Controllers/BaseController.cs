using eMAS.TerrenosComodatos.Domain.Application;
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eMAS.TerrenosComodatos.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly ICasesUsesGeneric _casesUsesGeneric;
        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger
            , ICasesUsesGeneric casesUsesGeneric
            )
        {
            _casesUsesGeneric = casesUsesGeneric;
            _logger = logger;
        }
        [HttpPost]
        public JsonResult GetDataDsrGeneric([FromBody] KeyValueParam paramKey)
        {
            var ls = _casesUsesGeneric.GetSingleDatasources(paramKey?.key1, paramKey?.target);

            return Json(ls);
        }
    }
}
