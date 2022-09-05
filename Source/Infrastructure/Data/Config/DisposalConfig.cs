using IToNeo.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IToNeo.Infrastructure.Data.Config
{
    class DisposalConfig : IEntityTypeConfiguration<EquipmentDisposal>
    {
        public void Configure(EntityTypeBuilder<EquipmentDisposal> builder)
        {
            builder.ToTable("Disposals");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd().HasMaxLength(36);

            builder.Property(d => d.Note).HasMaxLength(100);

            builder.Property(d => d.Name).HasMaxLength(50);

            builder.Property(d => d.Date).HasColumnType("Date");

            builder.HasOne(d => d.Equipment)
                .WithOne(e => e.Disposal)
                .HasForeignKey<EquipmentDisposal>(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(d => d.Timestamp).IsRowVersion();
        }
    }
}


