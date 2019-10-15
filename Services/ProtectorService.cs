using System;
using Microsoft.AspNetCore.DataProtection;

namespace netcoreAuthen.Services
{
    public class ProtectorService 
    {
        public readonly IDataProtectionProvider dataProtectionProvider;

        public ProtectorService(IDataProtectionProvider dataProtectionProvider)
        {
            this.dataProtectionProvider = dataProtectionProvider;
        }
    }
}
