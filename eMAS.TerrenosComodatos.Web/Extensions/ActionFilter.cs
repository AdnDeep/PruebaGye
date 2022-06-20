using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace eMAS.TerrenosComodatos.Web.Extensions
{
    public class TempDataActionFilter : IActionFilter
    {
        private AppSettings _appSettings;
        public TempDataActionFilter(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Controller controller = context.Controller as Controller;
            if (controller != null)
            {
                controller.TempData["RutaBase"] = _appSettings.RutaBase;            
            }
        }
    }
}
