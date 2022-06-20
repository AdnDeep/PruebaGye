using eMAS.TerrenosComodatos.Domain.Application.CaseUses;
using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Web.Controllers;
using eMAS.TerrenosComodatos.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMAS.TerrenosComodatos.Web.Areas.Comodatos.Controllers
{
    [Area("Comodatos")]
    public class STC50001Controller : BaseController
    {
        private readonly ILogger<STC50001Controller> _logger;
        private readonly ICaseUseLecturaBeneficiario _caseUseLecturaBeneficiario;
        private readonly ICaseUseEscribirBeneficiario _caseUseEscrituraBeneficiario;
        public STC50001Controller(ILogger<STC50001Controller> logger, ILogger<BaseController> loggerBase
            , ICaseUseLecturaBeneficiario caseUseLecturaBeneficiario
            , ICaseUseEscribirBeneficiario caseUseEscrituraBeneficiario) 
            : base(loggerBase, caseUseLecturaBeneficiario)
        {
            _caseUseLecturaBeneficiario = caseUseLecturaBeneficiario;
            _caseUseEscrituraBeneficiario = caseUseEscrituraBeneficiario;
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
            BeneficiarioEditModel editModel = null;

            try
            {
                short sId = 0;
                Int16.TryParse(id, out sId);
                var resultadoCasoUso = _caseUseLecturaBeneficiario.LeerPorId(sId);

                if (resultadoCasoUso.mensaje == "OK")
                {
                    editModel = resultadoCasoUso.dataresult;
                    partialEditViewHtml = await this.RenderViewAsync("_EditForm", editModel, true);
                    response.SetResultadoViewJson(true, "OK", string.Empty, partialEditViewHtml);
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
        public IActionResult EditSave(BeneficiarioEditModel modelEdit)
        {
            string partialEditViewHtml = string.Empty;
            ResultadoDTO<BeneficiarioEditModel> response = new ResultadoDTO<BeneficiarioEditModel>();            
            try
            {
                response = _caseUseEscrituraBeneficiario.GrabarBeneficiario(modelEdit, "test", "STC50001", "WEBCLIENT");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                response.mensaje = "Se produjo un error en el aplicativo.";
                response.tipo = "ADVERTENCIA";
            }

            return Json(response);
        }
    }
}
