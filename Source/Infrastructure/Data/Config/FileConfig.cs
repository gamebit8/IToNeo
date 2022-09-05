using IToNeo.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IToNeo.Infrastructure.Data.Config
{
    class FileConfig : IEntityTypeConfiguration<FileEntity>
    {

        public FileConfig()
        {
        }

        public void Configure(EntityTypeBuilder<FileEntity> builder)
        {
            builder.ToTable("Files");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd().HasMaxLength(36);

            builder.Property(f => f.Name).HasMaxLength(50).IsRequired();

            builder.Property(f => f.Content).HasMaxLength(2097152).IsRequired();
            
            builder.HasOne(f => f.Employee)
                .WithOne(e => e.File)
                .HasForeignKey<FileEntity>(f => f.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Equipment)
                .WithOne(e => e.File)
                .HasForeignKey<FileEntity>(f => f.EquipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.SoftwareLicense)
                .WithOne(s => s.File)
                .HasForeignKey<FileEntity>(f => f.SoftwareLicenseId);

            builder.Property(f => f.Timestamp).IsRowVersion();
        }
    }
}


