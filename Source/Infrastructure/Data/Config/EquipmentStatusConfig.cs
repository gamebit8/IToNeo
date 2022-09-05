using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace IToNeo.Infrastructure.Data.Config
{
    public class EquipmentStatusConfig : IEntityTypeConfiguration<EquipmentStatus>
    {
        public void Configure(EntityTypeBuilder<EquipmentStatus> builder)
        {
            builder.ToTable("EquipmentStatuses");

            builder.HasKey(es => es.Id);
            builder.Property(es => es.Id).ValueGeneratedOnAdd().HasMaxLength(36);

            builder.Property(es => es.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(es => es.Name).IsUnique();

            builder.Property(es => es.Timestamp).IsRowVersion();
        }
    }
}
