using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IToNeo.Infrastructure.Data.Config
{
    class SoftwareDeveloperConfig : IEntityTypeConfiguration<SoftwareDeveloper>
    {
        public void Configure(EntityTypeBuilder<SoftwareDeveloper> builder)
        {
            builder.ToTable("SoftwareDevelopers");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedOnAdd().HasMaxLength(36);

            builder.Property(d => d.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(d => d.Name).IsUnique();

            builder.Property(d => d.Timestamp).IsRowVersion();
        }
    }
}


