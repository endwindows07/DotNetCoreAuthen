using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LoginModel = netcoreAuthen.Models.LoginModel;
using RegisterModel = netcoreAuthen.Models.RegisterModel;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace netcoreAuthen.Services
{
    public class AccountService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUser(RegisterModel model)
        {
            IdentityUser newUser = new IdentityUser { Email = model.Email, UserName = model.Email };
            IdentityResult result = await userManager.CreateAsync(newUser, model.Password);

            // Add all new users to the User role
            await userManager.AddToRoleAsync(newUser, "User");

            // Add new users whose email starts with 'admin' to the Admin role
            if (newUser.Email.StartsWith("admin", System.StringComparison.Ordinal))
            {
                await userManager.AddToRoleAsync(newUser, "Admin");
            }

            //var identity = new GenericIdentity(UserVerify.Username);
            return result;
        }

        public async Task<SignInResult> Login(LoginModel login)
        {

            //var user = await userManager.FindByEmailAsync(login.Email);
            //bool _result = await userManager.CheckPasswordAsync(user, login.Password);
            SignInResult result = await signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
           
            if (!result.Succeeded) return result;
            return result;
        }
    }
}
