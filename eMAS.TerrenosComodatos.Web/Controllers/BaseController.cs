using eMAS.TerrenosComodatos.Domain.Application;
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var ls = _casesUsesGeneric.GetSingleDatasources(paramKey?.key1, paramKey?.keyentity, paramKey?.target);

            return Json(ls);
        }
        protected string GetUserFromContext()
        {
            var parametros = $"BaseController Service Layer";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "GetUserFromContext" },
                                { "Sitio", "COMODATO-WEB" },
                                { "Parametros", parametros }
                        };
            string userName = string.Empty;
            string userNameComplete = HttpContext?.User?.Claims?.FirstOrDefault(w => w.Type == "preferred_username")?.Value;
            try
            {
                userName = userNameComplete.Split("@")[0];
                if (!string.IsNullOrEmpty(userName))
                    userName = userName.ToUpper();
            }
            catch (Exception ex)
            {
                using (_logger.BeginScope(props))
                {
                    _logger.LogError($"Se produjo una excepción al consultar el usuario {ex}");
                }
                userName = "";
            }
            return userName;
        }
    }
}
