using IToNeo.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IToNeo.Infrastructure.Data.Config
{
    class WriteOffConfig : IEntityTypeConfiguration<EquipmentWriteOff>
    {
        public void Configure(EntityTypeBuilder<EquipmentWriteOff> builder)
        {
            builder.ToTable("WriteOffs");

            builder.HasKey(w => w.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd().HasMaxLength(36);

            builder.Property(w => w.Note).HasMaxLength(100);

            builder.Property(w => w.Name).HasMaxLength(50);

            builder.Property(w => w.Date).HasColumnType("Date");

            builder.HasOne(w => w.Equipment)
                .WithOne(e => e.WriteOff)
                .HasForeignKey<EquipmentWriteOff>(w => w.EquipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(s => s.Timestamp).IsRowVersion();
        }
    }
}
