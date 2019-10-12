using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace netcoreAuthen.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> userManager;

        public JwtService(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            this.userManager = userManager;
        }

        public async Task<string> GenerateKey(string username)
        {
            // หา user identity เพื่อใช้ในการค้นหา role user เพื่อทำการดึง role มาสร้าง claim ในการ Authorizetion
            var user = await userManager.FindByEmailAsync(username);
            var roles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>();
            // เพิ่ม claim email  ระบบลง token
            claims.Add(new Claim(ClaimTypes.Name, user.Email));

            foreach (var role in roles)
            {
                // เพิ่ม claim role ลง token
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
