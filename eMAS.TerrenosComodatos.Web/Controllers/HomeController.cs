using eMAS.TerrenosComodatos.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SeguridadError()
        {
            ViewBag.Nombre = HttpContext.User?.Claims?.FirstOrDefault(fod => fod.Type == "name")?.Value ?? HttpContext.User.Identity.Name;
            ViewData["ErrorMessage"] = "Estimado usuarios, no tiene permiso para ingresar a este controlador";
            return View("Error");
        }
    }
}
