using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace IToNeo.Infrastructure.Data
{
    public partial class IToNeoContext : DbContext
    {
        public IToNeoContext(DbContextOptions<IToNeoContext> options) 
            : base(options)
        {

        }

        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }
        public virtual DbSet<EquipmentStatus> EquipmentStatuses { get; set; }
        public virtual DbSet<EquipmentDisposal> Disposals { get; set; }
        public virtual DbSet<EquipmentWriteOff> WriteOffs { get; set; }
        public virtual DbSet<FileEntity> Files { get; set; }
        public virtual DbSet<Software> Softwares { get; set; }
        public virtual DbSet<SoftwareDeveloper> SoftwareDevelopers { get; set; }
        public virtual DbSet<SoftwareLicense> SoftwareLicenses { get; set; }
        public virtual DbSet<SoftwareLicenseType> SoftwareLicenseTypes { get; set; }
        public virtual DbSet<EquipmentSoftwareLicense> EquipmentsSoftwareLicences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DisposalConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new EquipmentConfig());
            modelBuilder.ApplyConfiguration(new EquipmentStatusConfig());
            modelBuilder.ApplyConfiguration(new EquipmentTypeConfig());
            modelBuilder.ApplyConfiguration(new FileConfig());
            modelBuilder.ApplyConfiguration(new OrganizationConfig());
            modelBuilder.ApplyConfiguration(new PlaceConfig());
            modelBuilder.ApplyConfiguration(new SoftwareConfig());
            modelBuilder.ApplyConfiguration(new SoftwareDeveloperConfig());
            modelBuilder.ApplyConfiguration(new SoftwareLicenseConfig());
            modelBuilder.ApplyConfiguration(new SoftwareLicenseTypeConfig());
            modelBuilder.ApplyConfiguration(new WriteOffConfig());
        }
    }
}
