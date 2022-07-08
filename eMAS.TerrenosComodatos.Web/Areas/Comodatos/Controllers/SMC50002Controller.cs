﻿using eMAS.TerrenosComodatos.Domain.Application;
using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Web.Controllers;
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
    }
}
