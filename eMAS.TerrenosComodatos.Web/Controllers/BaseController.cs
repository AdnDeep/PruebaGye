﻿using eMAS.TerrenosComodatos.Domain.Application.CaseUses;
using eMAS.TerrenosComodatos.Domain.DTOs;
using eMAS.TerrenosComodatos.Web.Extensions;
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
    public abstract class BaseController : Controller
    {
        private readonly ICaseUseLecturaBeneficiario _caseUseLecturaBeneficiario;
        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger
            , ICaseUseLecturaBeneficiario caseUseLecturaBeneficiario
            )
        {
            _logger = logger;
            _caseUseLecturaBeneficiario = caseUseLecturaBeneficiario;
        }


        [HttpPost]
        public ActionResult GetPagedData(string data
            , string typeSearch
            , string resultContainer
            , int numeroPagina = 1
            , int tamanioPagina = 5)
        {
            if (typeSearch == "beneficiarios") 
            {
                ResultadoDTO<DataPagineada<BeneficiariosViewModel>> resultadoVista = new ResultadoDTO<DataPagineada<BeneficiariosViewModel>>();

                resultadoVista = _caseUseLecturaBeneficiario.LeerTodosPaginado(data, resultContainer, numeroPagina, tamanioPagina);
                
                return Json(resultadoVista);
            }


            return Json(new { saludo="hola"});
        }
    }
}
