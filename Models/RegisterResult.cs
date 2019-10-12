﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace netcoreAuthen.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterResult
    {
        public RegisterResult(bool successful, IEnumerable<string> errors)
        {
            Successful = successful;
            Errors = errors;
        }

        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
