using IToNeo.Infrastructure.Identity.Config;
using IToNeo.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IToNeo.Infrastructure.Identity
{
    public class IToNeoIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
                ApplicationUserRole, IdentityUserLogin<string>,
                IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public IToNeoIdentityDbContext(DbContextOptions<IToNeoIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserConfig());
        }
    }

}
