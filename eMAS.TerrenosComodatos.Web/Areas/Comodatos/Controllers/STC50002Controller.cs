using eMAS.TerrenosComodatos.Domain.Application.CaseUses;
using eMAS.TerrenosComodatos.Domain.Auxiliars;
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
    public class STC50002Controller : BaseController
    {
        public STC50002Controller(ILogger<STC50002Controller> logger, ILogger<BaseController> loggerBase
            , ICaseUseLecturaBeneficiario caseUseLecturaBeneficiario
            , GenericDataProvider genericDataProvider)
            :base(loggerBase, caseUseLecturaBeneficiario, genericDataProvider)
        { 
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
