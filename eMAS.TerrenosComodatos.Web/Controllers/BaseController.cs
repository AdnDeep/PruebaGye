using eMAS.TerrenosComodatos.Domain.Application;
using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet]
        public ActionResult GetReportGeneralSystem(string idreporte)
        {
            if (string.IsNullOrEmpty(idreporte) || string.IsNullOrWhiteSpace(idreporte))
            {
                ViewData["ErrorMessage"] = "No existe reporte para imprimir. [1]";
                return View("Error");
            }

            string strObj = TempData[idreporte] as string;
            TramiteReportClientViewModel obj = JsonConvert.DeserializeObject<TramiteReportClientViewModel>(strObj);

            if (obj == null)
            {
                ViewData["ErrorMessage"] = "No existe reporte para imprimir. [2]";
                return View("Error");
            }

            if (obj.canContinue) 
            {
                var bytPdf = Convert.FromBase64String(obj.contentReport);

                TempData.Remove(idreporte);
                return File(new MemoryStream(bytPdf), "application/octet-stream", obj.fileName);
            }
            else
            {
                TempData.Remove(idreporte);
                ViewData["ErrorMessage"] = obj.mensaje;
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult ExportDataSystem([FromBody] ExportSingleRequest request)
        {
            ResultadoDTO<int> response = new ResultadoDTO<int>();
            response.tipo = "EXITO";

            var respuestaServidor = _casesUsesGeneric.GetSingleExport(request);

            if (respuestaServidor.tipo == "ADVERTENCIA")
            {
                response.mensaje = respuestaServidor.mensaje;
                response.tipo = "ADVERTENCIA";
            }
            else
            {
                string hashString = StringManipulation.GenerateRandom();
                if (TempData[hashString] != null)
                    TempData.Remove(hashString);

                TempData[hashString] = JsonConvert.SerializeObject(respuestaServidor.dataresult);
                TempData.Keep(hashString);
                response.mensaje = hashString;
                response.tipo = "EXITO";
            }

            return Json(new { tipo = response.tipo, mensaje = response.mensaje, rutaretorno = respuestaServidor.dataresult?.RutaRetorno });
        }
        [HttpGet]
        public ActionResult GetExportDataCsvSystem(string idexport)
        {
            if (string.IsNullOrEmpty(idexport) || string.IsNullOrWhiteSpace(idexport))
            {
                ViewData["ErrorMessage"] = "No existe reporte para imprimir. [1]";
                return View("Error");
            }
            
            if (TempData[idexport] == null)
            {
                ViewData["ErrorMessage"] = "No existe reporte para imprimir. [2]";
                return View("Error");
            }

            string strObj = TempData[idexport] as string;


            ExportSingleResult obj = JsonConvert.DeserializeObject<ExportSingleResult>(strObj);

            TempData.Remove(idexport);
            return File(new MemoryStream(obj.bytecontenidoarchivo), "application/csv", obj.nombrearchivo);
            
        }
    }
}
