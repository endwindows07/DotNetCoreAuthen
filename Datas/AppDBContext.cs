using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace netcoreAuthen.Datas
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // create mock role data
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
        }
    }

    // การเพิ่ม Custom User Identity
    public class AppDBContextCustom : IdentityDbContext<CustomUserApp>
    {
        public AppDBContextCustom(DbContextOptions<AppDBContextCustom> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // create mock role data
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
        }
    }



    // การทำ Custom Identity User
    public class CustomUserApp : IdentityUser
    {
        //เพิ่ม property ที่ยต้องการ

    }
}
