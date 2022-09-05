using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IToNeo.ApplicationCore.Entities;


namespace IToNeo.Infrastructure.Data.Config
{
    class OrganizationConfig : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations");

            builder.HasKey(o => o.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd().HasMaxLength(36);

            builder.Property(o => o.Name).HasMaxLength(50).IsRequired();
            builder.HasIndex(o => o.Name).IsUnique();

            builder.Property(o => o.Timestamp).IsRowVersion();
        }
    }
}
