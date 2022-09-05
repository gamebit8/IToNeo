using IToNeo.Infrastructure.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IToNeo.Infrastructure.Identity.Config
{
    class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("AspNetUserUsers");

            builder.HasMany(au => au.Roles)
                .WithMany(ar => ar.Users)
                .UsingEntity<ApplicationUserRole>(
                    j => j
                        .HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId),
                   j => j
                        .HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId),
                  j => j
                       .HasKey(t => new { t.UserId, t.RoleId })
                );

        }
    }
}


