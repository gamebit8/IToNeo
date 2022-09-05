using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.Infrastructure.Data.ValueGenerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IToNeo.Infrastructure.Data.Config
{
    class EquipmentConfig : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipments");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd().HasMaxLength(36);

            builder.Property(e => e.Name).HasMaxLength(255).IsRequired();

            builder.Property(e => e.InventoryNumber).HasValueGenerator<InventoryNumberGenerator>().HasMaxLength(50);

            builder.Property(e => e.SerialNumber).HasMaxLength(50);

            builder.Property(e => e.Note).HasMaxLength(100);

            builder.HasOne(e => e.Status)
                .WithMany(e => e.Equipments)
                .HasForeignKey(e => e.StatusId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(e => e.Place)
                .WithMany(p => p.Equipments)
                .HasForeignKey(e => e.PlaceId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(e => e.Organization)
                .WithMany(o => o.Equipments)
                .HasForeignKey(e => e.OrganizationId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.HasOne(e => e.Type)
                .WithMany(t => t.Equipments)
                .HasForeignKey(e => e.TypeId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            builder.Property(e => e.DateOfCreation).HasDefaultValueSql("CURRENT_DATE").HasColumnType("Date");

            builder.Property(e => e.DateOfInstallation).HasColumnType("Date");

            builder.HasOne(e => e.Employee)
                .WithMany(e => e.Equipments)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(e => e.Timestamp).IsRowVersion();
        }
    }
}
