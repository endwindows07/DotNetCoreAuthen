using System;
using System.ComponentModel.DataAnnotations;

namespace netcoreAuthen.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class LoginResult
    {
        public LoginResult(bool successful, string error, string token)
        {
            Successful = successful;
            Error = error;
            Token = token;
        }

        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}
