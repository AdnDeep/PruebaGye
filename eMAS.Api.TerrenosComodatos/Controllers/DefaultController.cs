using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMAS.Api.TerrenosComodatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class DefaultController : ControllerBase
    {
        private string userId;
        protected string UserId 
        {
            get { return userId; }
        }
        public DefaultController(IHttpContextAccessor httpContextAccessor)
        {
            var strUserWithDomain = httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(w => w.Type == "preferred_username")?.Value;
            if (!(string.IsNullOrEmpty(strUserWithDomain) || string.IsNullOrWhiteSpace(strUserWithDomain)))
            {
                try
                {
                    this.userId = strUserWithDomain.Split("@")[0];
                }
                catch (Exception)
                {
                    this.userId = "";
                }
            }
        }
    }
}
