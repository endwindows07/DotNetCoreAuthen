using System;
using Microsoft.AspNetCore.Authorization;

namespace netcoreAuthen.Datas
{
    public class CompanyDomainRequirementPolicy : IAuthorizationRequirement
    {
        public readonly string companyDomain;

        public CompanyDomainRequirementPolicy(string companyDomain)
        {
            this.companyDomain = companyDomain;
        }
    }
}
