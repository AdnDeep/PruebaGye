using eMAS.TerrenosComodatos.Domain.Application;
using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Web.Controllers;
using eMAS.TerrenosComodatos.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Web.Areas.Comodatos.Controllers
{
    [Area("Comodatos")]
    public class SMC50001Controller : BaseController
    {
        private readonly ICasesUsesGestionBeneficiario _casesUsesBeneficiario;
        private readonly ILogger<SMC50001Controller> _logger;
        public SMC50001Controller(ILogger<SMC50001Controller> logger
            , ICasesUsesGestionBeneficiario casesUsesBeneficiario
            , ILogger<BaseController> loggerBase
            , ICasesUsesGeneric casesUsesGeneric
            ) 
            : base(loggerBase, casesUsesGeneric)
        {
            _casesUsesBeneficiario = casesUsesBeneficiario;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditView(string id) 
        {
            string partialEditViewHtml = string.Empty;
            var response = new ResultadoViewJson();
            BeneficiarioEditViewModel editModel = null;

            try
            {
                short sId = 0;
                Int16.TryParse(id, out sId);
                var resultadoCasoUso = _casesUsesBeneficiario.LeerPorId(sId);

                if (resultadoCasoUso.tipo == "EXITO")
                {
                    editModel = resultadoCasoUso.dataresult;
                    partialEditViewHtml = await this.RenderViewAsync("_EditForm", editModel, true);
                    response.SetResultadoViewJson(true, "EXITO", string.Empty, partialEditViewHtml);
                }
                else
                {
                    response.SetResultadoViewJson(false, resultadoCasoUso.tipo, resultadoCasoUso.mensaje);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                response.SetResultadoViewJson(false, "ADVERTENCIA", "Se produjo un error al generar el formulario de Edición.");
            }
            
            return Json(response);
        }
        [HttpPost]
        public IActionResult EditSave(BeneficiarioEditViewModel modelEdit)
        {
            string partialEditViewHtml = string.Empty;
            ResultadoDTO<BeneficiarioEditViewModel> response = new ResultadoDTO<BeneficiarioEditViewModel>();            
            try
            {
                response = _casesUsesBeneficiario.GrabarBeneficiario(modelEdit, "test", "SMC50001", "WEBCLIENT");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                response.mensaje = "Se produjo un error en el aplicativo.";
                response.tipo = "ADVERTENCIA";
            }

            return Json(response);
        }
        [HttpPost]
        public IActionResult EditDelete(BeneficiarioDeleteViewModel modelEdit)
        {
            ResultadoDTO<BeneficiarioEditViewModel> response = new ResultadoDTO<BeneficiarioEditViewModel>();
            try
            {
                response = _casesUsesBeneficiario.EliminarBeneficiario(modelEdit, "test", "SMC50001", "WEBCLIENT");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                response.mensaje = "Se produjo un error en el aplicativo.";
                response.tipo = "ADVERTENCIA";
            }

            return Json(response);
        }
        [HttpPost]
        public ActionResult GetPagedData(string data
            , string typeSearch
            , string resultContainer
            , int numeroPagina = 1
            , int tamanioPagina = 5)
        {
            ResultadoDTO<DataPagineada<BeneficiarioListViewModel>> resultadoVista = new ResultadoDTO<DataPagineada<BeneficiarioListViewModel>>();

            resultadoVista = _casesUsesBeneficiario.LeerTodosPaginado(data, resultContainer, numeroPagina, tamanioPagina);

            return Json(resultadoVista);        
        }
    }
}
