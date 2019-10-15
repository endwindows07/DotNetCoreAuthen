using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using netcoreAuthen.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netcoreAuthen.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProtectorController : Controller
    {
        private readonly ProtectorService protectorService;

        public ProtectorController(ProtectorService protectorService)
        {
            this.protectorService = protectorService;
        }

        // GET: api/values
        [HttpGet]
        public string ProtectMessge(string key, string message)
        {
            IDataProtector result = protectorService.dataProtectionProvider.CreateProtector(key);
            string messageProtech = result.Protect(message);
            return messageProtech;
        }

        [HttpGet]
        public string UnProtectMessage(string key, string message)
        {
            IDataProtector result = protectorService.dataProtectionProvider.CreateProtector(key);
            string messageProtech = result.Unprotect(message);
            return messageProtech;
        }
    }
}
