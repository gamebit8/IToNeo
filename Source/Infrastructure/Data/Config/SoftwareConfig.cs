using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IToNeo.Infrastructure.Data.Config
{
    class SoftwareConfig : IEntityTypeConfiguration<Software>
    {
        public void Configure(EntityTypeBuilder<Software> builder)
        {
            builder.ToTable("Softwares");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasMaxLength(36);

            builder.Property(s => s.Note).HasMaxLength(100);

            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(s => s.Name).IsUnique();

            builder.HasOne(s => s.Developer).WithMany(d => d.Softwares).HasForeignKey(d => d.DeveloperId);

            builder.Property(s => s.Timestamp).IsRowVersion();
        }
    }
}


