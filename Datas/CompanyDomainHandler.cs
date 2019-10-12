using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace netcoreAuthen.Datas
{
    public class CompanyDomainHandler: AuthorizationHandler<CompanyDomainRequirementPolicy>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CompanyDomainRequirementPolicy requirement)
        {
            // หาก context ที่ได้มาไม่มี email ให้ออกทันที
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            // find email in context
            var emailAddress = context.User.FindFirst(c => c.Type == ClaimTypes.Email).Value;

            // หากตรงเงื่อนไข ก็ผ่านทันที
            if (emailAddress.StartsWith(requirement.companyDomain, StringComparison.Ordinal))
            {
                 context.Succeed(requirement);
                return Task.CompletedTask;

            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}
