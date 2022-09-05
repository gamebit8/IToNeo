using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IToNeo.Infrastructure.Data.Config
{
    class SoftwareLicenseConfig : IEntityTypeConfiguration<SoftwareLicense>
    {
        public void Configure(EntityTypeBuilder<SoftwareLicense> builder)
        {
            builder.ToTable("SoftwareLicenses");

            builder.HasKey(l => l.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd().HasMaxLength(36);

            builder.Property(l => l.Count).IsRequired();

            builder.Property(l => l.Name).HasMaxLength(50);

            builder.Property(l => l.LicenseCode).HasMaxLength(50);

            builder.Property(l => l.Note).HasMaxLength(100);

            builder.HasOne(l => l.Type)
                .WithMany(t => t.Licenses)
                .HasForeignKey(l => l.TypeId)
                .IsRequired();

            builder.HasOne(l => l.Software)
               .WithMany(s => s.Licenses)
               .HasForeignKey(l => l.SoftwareId)
               .IsRequired();

            builder.HasOne(l => l.Organization)
               .WithMany(o => o.SoftwareLicense)
               .HasForeignKey(l => l.OrganizationId)
               .IsRequired();

            builder.HasMany(l => l.Equipments)
                .WithMany(e => e.SoftwareLicenses);

            builder.HasMany(e => e.Equipments)
                .WithMany(sl => sl.SoftwareLicenses)
                .UsingEntity<EquipmentSoftwareLicense>(
                    j => j
                        .HasOne(esl => esl.Equipment)
                        .WithMany(e => e.EquipmentSoftwareLicences)
                        .HasForeignKey(esl => esl.EquipmentId),
                    j => j
                        .HasOne(esl => esl.SoftwareLicence)
                        .WithMany(sl => sl.EquipmentSoftwareLicences)
                        .HasForeignKey(esl => esl.SoftwareLicenceId),
                    j => {
                        j.HasKey(x => new { x.EquipmentId, x.SoftwareLicenceId });
                    }
                );

            builder.Property(e => e.Timestamp).IsRowVersion();
        }
    }
}


