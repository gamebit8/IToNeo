using IToNeo.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IToNeo.Infrastructure.Data.Config
{
    class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd().HasMaxLength(36);

            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();

            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();

            builder.Property(e => e.PatronymicName).HasMaxLength(50);

            builder.Property(e => e.Name)
                .HasComputedColumnSql(@"""LastName"" || ' ' || ""FirstName"" || ' ' || ""PatronymicName""", stored: true);

            builder.Property(e => e.Username).HasMaxLength(50);

            builder.Property(e => e.Department).HasMaxLength(50).IsRequired();

            builder.Property(e => e.Position).HasMaxLength(50).IsRequired();

            builder.HasIndex(e => new {e.FirstName, e.LastName, e.PatronymicName, e.Username, e.Position }).IsUnique();

            builder.HasOne(e => e.Organization)
                .WithMany(e => e.Employees)
                .HasForeignKey(w => w.OrganizationId)
                .IsRequired();

            builder.Property(e => e.Timestamp).IsRowVersion();
        }
    }
}