using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netcoreAuthen.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccessCaseController : Controller
    {
        [HttpGet]
        public string Nonauthen()
        {
            return "Nonauthen Data Access";
        }

        [HttpGet]
        [Authorize]
        public string AuthorizeToken()
        {
            return "AuthorizeToken Data Access";
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public string AuthorizeTokenRoleAdmin()
        {
            return "AuthorizeTokenRole admin Data Access";
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public string AuthorizeTokenRoleUser()
        {
            return "AuthorizeTokenRole admin Data Access";
        }

        [HttpGet]
        [Authorize(Policy = "IsSuperuser")]
        public string AuthorizeTokenPolicy()
        {
            return "AuthorizeTokenPolicy Data Access";
        }
    }
}
