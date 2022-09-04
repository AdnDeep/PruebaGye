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
            string userNameViewUser = context.HttpContext.User?.Claims?.FirstOrDefault(fod => fod.Type == "name")?.Value ?? context.HttpContext.User.Identity.Name;
            var controller = context.Controller as Controller;
            controller.ViewData["username"] = userNameViewUser;
            var nameController = controller?.ControllerContext?.ActionDescriptor?.ControllerName;

            if (nameController == "SMC50001" || nameController == "SMC50002")
            {
                string permiso = context.HttpContext.Session.GetObject<string>(nameController);
                string mensajeError = "";
                if (string.IsNullOrEmpty(permiso) || string.IsNullOrWhiteSpace(permiso))
                {
                    //permiso = "S";
                    permiso = _casesUsesSeguridad.ObtenerPermisosPorUsuario(userName, nameController, ref mensajeError);
                    context.HttpContext.Session.SetObject(nameController, permiso);
                }
                if (permiso != "S")
                {
                    if (!(string.IsNullOrEmpty(mensajeError) || string.IsNullOrWhiteSpace(mensajeError)) && mensajeError != "OK")
                    {
                        controller.TempData["ERROR_API_SEGURIDAD"] = $"{mensajeError} Es probable que necesite cerrar e iniciar sesión nuevamente.";
                        controller.TempData.Keep();
                    }
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
