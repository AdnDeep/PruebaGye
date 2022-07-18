using eMAS.TerrenosComodatos.Domain.Application;
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
    public class SMC50002Controller : BaseController
    {
        private readonly ICasesUsesGestionTramite _casesUsesTramite;
        private readonly ILogger<SMC50002Controller> _logger;
        public SMC50002Controller(ILogger<SMC50002Controller> logger
            , ILogger<BaseController> loggerBase
            , ICasesUsesGestionTramite casesUsesTramite
            , ICasesUsesGeneric casesUsesGeneric)
            :base(loggerBase, casesUsesGeneric)
        {
            _logger = logger;
            _casesUsesTramite = casesUsesTramite;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditView(string id)
        {
            string partialEditViewHtml = string.Empty;
            var response = new ResultadoViewJson();
            TramiteEditViewModel editModel = null;

            try
            {
                short sId = 0;
                Int16.TryParse(id, out sId);
                var resultadoCasoUso = _casesUsesTramite.LeerPorId(sId);

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
        public IActionResult EditSave(TramiteEditViewModel modelEdit)
        {
            string partialEditViewHtml = string.Empty;
            ResultadoDTO<int> response = new ResultadoDTO<int>();
            try
            {
                response = _casesUsesTramite.GrabarTramite(modelEdit, "test", "SMC50002", "WEBCLIENT");
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
        public IActionResult EditDelete(short id)
        {
            ResultadoDTO<int> response = new ResultadoDTO<int>();
            try
            {
                response = _casesUsesTramite.EliminarTramite(id, "test", "SMC50002", "WEBCLIENT");
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
            ResultadoDTO<DataPagineada<TramiteListViewModel>> resultadoVista = new ResultadoDTO<DataPagineada<TramiteListViewModel>>();

            resultadoVista = _casesUsesTramite.LeerTodosPaginado(data, resultContainer, numeroPagina, tamanioPagina);

            return Json(resultadoVista);
        }

        #region Generic Detail
        [HttpPost]
        public IActionResult GetListDetail([FromBody]TramitesListRequestViewModel request) 
        {
            object resultadoVista = new object();

            resultadoVista = _casesUsesTramite.LeerDetalleListaTodos(request?.idtramite ?? 0, request?.entidad);

            return Json(resultadoVista);
        }
        #endregion
    }
}
