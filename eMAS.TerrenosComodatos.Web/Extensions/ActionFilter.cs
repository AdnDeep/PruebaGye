using eMAS.TerrenosComodatos.Domain.Application;
using eMAS.TerrenosComodatos.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System.Linq;

namespace eMAS.TerrenosComodatos.Web.Extensions
{
    public class TempDataActionFilter : IActionFilter
    {
        private readonly ICasesUsesGestionSeguridad _casesUsesSeguridad;
        private AppSettings _appSettings;
        public TempDataActionFilter(IOptions<AppSettings> appSettings
            , ICasesUsesGestionSeguridad casesUsesSeguridad)
        {
            _casesUsesSeguridad = casesUsesSeguridad;
            _appSettings = appSettings.Value;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string userName = context.HttpContext?.User?.Claims?.FirstOrDefault(w => w.Type == "preferred_username")?.Value;

            var controller = context.Controller as Controller;

            var nameController = controller?.ControllerContext?.ActionDescriptor?.ControllerName;

            if (nameController == "SMC50001" || nameController == "SMC50002")
            {
                string permiso = context.HttpContext.Session.GetObject<string>(nameController);

                if (string.IsNullOrEmpty(permiso) || string.IsNullOrWhiteSpace(permiso))
                {
                    //permiso = "S";
                    permiso = _casesUsesSeguridad.ObtenerPermisosPorUsuario(userName, nameController);
                    context.HttpContext.Session.SetObject(nameController, permiso);
                }
                if (permiso != "S")
                {
                    string rutaBase = _appSettings.RutaBase;
                    rutaBase = rutaBase == "/" ? "/" : rutaBase + "/";

                    context.HttpContext.Session.Clear();

                    context.HttpContext.Response.Redirect($"{rutaBase}Home/SeguridadError");                    
                }
            }
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
