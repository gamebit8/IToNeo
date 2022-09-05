using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IToNeo.Infrastructure.Data.Config
{
    class SoftwareLicenseTypeConfig : IEntityTypeConfiguration<SoftwareLicenseType>
    {
        public void Configure(EntityTypeBuilder<SoftwareLicenseType> builder)
        {
            builder.ToTable("SoftwareLicenseType");

            builder.HasKey(lt => lt.Id);
            builder.Property(lt => lt.Id).ValueGeneratedOnAdd().HasMaxLength(36);

            builder.Property(lt => lt.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(lt => lt.Name).IsUnique();

        }
    }
}


