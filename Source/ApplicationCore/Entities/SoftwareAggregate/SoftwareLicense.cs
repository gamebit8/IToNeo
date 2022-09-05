using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace IToNeo.ApplicationCore.Entities.SoftwareAggregate
{
    public class SoftwareLicense : BaseEntity, IUpdateEntity<SoftwareLicense>
    {
        public string Name { get; set; }
        public string TypeId { get; set; }
        public virtual SoftwareLicenseType Type { get; set; }
        public int Count { get; set; }
        public string LicenseCode { get; set; }
        public string SoftwareId { get; set; } 
        public virtual Software Software { get; set; }
        public string Note { get; set; }
        public string OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual FileEntity File { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; } = new HashSet<Equipment>();
        public virtual ICollection<EquipmentSoftwareLicense> EquipmentSoftwareLicences { get; set; } = new HashSet<EquipmentSoftwareLicense>();

        public SoftwareLicense() { }
        public SoftwareLicense(string typeId, int count, string codeLisense, string softwareId, string note, string organizationId)
        {
            TypeId = typeId;
            Count = count;
            LicenseCode = codeLisense;
            SoftwareId = softwareId;
            Note = note;
            OrganizationId = organizationId;
        }

        public void Update(SoftwareLicense entity)
        {
            Name = entity.Name;
            TypeId = Guard.Against.Null(entity.TypeId, nameof(entity.TypeId));
            Count = Guard.Against.Null(entity.Count, nameof(entity.Count));
            LicenseCode = Guard.Against.NullOrEmpty(entity.LicenseCode, nameof(entity.LicenseCode));
            SoftwareId = Guard.Against.Null(entity.SoftwareId, nameof(entity.SoftwareId));
            OrganizationId = Guard.Against.Null(entity.OrganizationId, nameof(entity.OrganizationId));
            Note = entity.Note;
        }
    }
}
