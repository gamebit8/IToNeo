using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IToNeo.Infrastructure.Data.Config
{
    class EquipmentTypeConfig : IEntityTypeConfiguration<EquipmentType>
    {
        public void Configure(EntityTypeBuilder<EquipmentType> builder)
        {
            builder.ToTable("EquipmentTypes");

            builder.HasKey(et => et.Id);

            builder.Property(et => et.Id).ValueGeneratedOnAdd().HasMaxLength(36);

            builder.Property(et => et.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(et => et.Name).IsUnique();

            builder.Property(et => et.Timestamp).IsRowVersion();
        }
    }
}
