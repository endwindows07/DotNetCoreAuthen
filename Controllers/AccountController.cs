using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netcoreAuthen.Services;
using Microsoft.AspNetCore.Identity;
using netcoreAuthen.Models;
using LoginModel = netcoreAuthen.Models.LoginModel;
using RegisterModel = netcoreAuthen.Models.RegisterModel;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netcoreAuthen.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService accountService;
        private readonly JwtService  jwtService;

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            this.accountService = new AccountService(userManager, signInManager);
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            jwtService = new JwtService(this.configuration, userManager);
        }

        public AccountService AccountService => accountService;

        public JwtService JwtService => jwtService;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel loginData)
        {
            var signInResult = await AccountService.Login(loginData);

            return !signInResult.Succeeded
               ? BadRequest(new LoginResult(false, "Username or Password Is Valid", null))
               : (IActionResult)Ok(new LoginResult(false, "Login is Success", await JwtService.GenerateKey(loginData.Email)));
        } 


        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterModel registerData)
        {
            var registerResult = await AccountService.RegisterUser(registerData);

            return !registerResult.Succeeded
                ? BadRequest(new RegisterResult(false, registerResult.Errors.Select(it => it.Description)))
                : (IActionResult)Ok(new RegisterResult(true, null));
        }
    }
}
