﻿using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Web.Models;
using eMAS.TerrenosComodatos.Web.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Web.Controllers
{
    public class HomeController : Controller
    {
        private AppSettings _appSettings;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger
            , IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
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
        public IActionResult LogIn()
        {
            return RedirectToAction("SignIn", "Account", new { Area = "MicrosoftIdentity" });

        }
        public IActionResult LogOut()
        {
            string rutaBase = _appSettings.RutaBase;
            rutaBase = rutaBase == "/" ? "/" : rutaBase;
            HttpContext.Session.Clear();
            return SignOut
            (
                new AuthenticationProperties { RedirectUri = $"{rutaBase}" },
                CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme
            );

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SeguridadError()
        {
            string mensajeErrApiSeguridad = "";
            if (TempData["ERROR_API_SEGURIDAD"] != null)
            {
                mensajeErrApiSeguridad = TempData["ERROR_API_SEGURIDAD"] as string;
                TempData.Remove("ERROR_API_SEGURIDAD");
            }
            string _nombre = HttpContext.User?.Claims?.FirstOrDefault(fod => fod.Type == "name")?.Value ?? HttpContext.User.Identity.Name;
            ViewData["ErrorMessage"] = $"Estimado usuario {_nombre}, no tiene permiso para ingresar a este controlador. {mensajeErrApiSeguridad}";
            return PartialView("Error");
        }
        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            ViewData["code"] = code;
            ViewData["ErrorMessage"] = MessagesApp.GetMessageByStatusCode(code);
            return PartialView("HandleError");
        }
    }
}
