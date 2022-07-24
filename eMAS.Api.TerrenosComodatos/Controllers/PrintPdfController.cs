using eMAS.Api.TerrenosComodatos.Extensions;
using eMAS.Api.TerrenosComodatos.IServices;
using eMAS.Api.TerrenosComodatos.Services;
using eMAS.Api.TerrenosComodatos.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintPdfController : ControllerBase
    {
        private readonly RenderViewService _razorViewService;
        private readonly IServiceTramiteLectura _serviceTramiteLectura;
        private readonly ILogger<PrintPdfController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ServiceConvertirHtmlAPdf _servicePdf;
        public PrintPdfController(RenderViewService razorViewService
            , IServiceTramiteLectura serviceTramiteLectura
            , ILogger<PrintPdfController> logger
            , IWebHostEnvironment hostEnvironment
            , ServiceConvertirHtmlAPdf servicePdf)
        {
            _servicePdf = servicePdf;
            _hostEnvironment = hostEnvironment;
            _serviceTramiteLectura = serviceTramiteLectura;
            _razorViewService = razorViewService;
            _logger = logger;
        }
        [HttpGet]
        [Route("GetSingleTramiteDsr")]
        public async Task<IActionResult> GetSingleTramiteDsr(short idEntity)
        {
            var parametros = $"PrintPdfController Service Layer Try: id {idEntity}";
            var props = new Dictionary<string, object>(){
                                { "Metodo", "GetSingleTramiteDsr" },
                                { "Sitio", "COMODATO-API" },
                                { "Parametros", parametros }
                        };
            string reportPath = "";
            string strReport = "";
            byte[] pdfContent = null;
            ResultadoDTO<TramiteEditViewModel> data = new ResultadoDTO<TramiteEditViewModel>();
            ResultadoDTO<TramiteReportServerViewModel> resultado = new ResultadoDTO<TramiteReportServerViewModel>();
            data = _serviceTramiteLectura.ObtenerDataInformeGeneral(idEntity);
            TramiteEditViewModel model = null;
            model = data.dataresult;
            if (model == null)
            {
                resultado.tipo = "ADVERTENCIA";
                resultado.mensaje = "No se encontraron Datos en el servidor.";

                return Ok(resultado);
            }
            try
            {
                model= data.dataresult;
                model = model ?? new TramiteEditViewModel();
                string imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Referencial/Images/logo1.png");
                
                reportPath = "Tramite/InformeGeneral";
                data.dataresult.srcimage = imagePath;
                
                strReport = await _razorViewService.GetHtmlViewAsStringAsync(reportPath, model);

                var respuesta = _servicePdf.ConvertirHtmlAPdf(strReport);
                pdfContent = respuesta.Item3;

                string base64Pdf = Convert.ToBase64String(pdfContent);

                string fileName = $"tramite_{model.anio}_{model.secuencia}";

                resultado.dataresult = new TramiteReportServerViewModel { contentReport = base64Pdf, fileName = fileName };

                return Ok(resultado);
            }
            catch (Exception e)
            {
                using (_logger.BeginScope(props)) 
                {
                    _logger.LogError($"Se produjo un error al generar el reporte. Excepcion: {e}");
                }
                resultado.tipo = "ADVERTENCIA";
                resultado.mensaje = "Se produjo un error en el aplicativo. Funcionalidad Impresion.";
                
                return Ok(resultado);
            }                      
        }
    }
}
