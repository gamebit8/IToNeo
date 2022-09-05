using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace IToNeo.ApplicationCore.Entities.SoftwareAggregate
{
    public class SoftwareLicenseType : BaseEntity, IUpdateEntity<SoftwareLicenseType>
    {
        public string Name { get; set; }
        public ICollection<SoftwareLicense> Licenses { get; set; } = new HashSet<SoftwareLicense>();

        public SoftwareLicenseType() { }
        public SoftwareLicenseType(string name)
        {
            Name = name;
        }

        public void Update(SoftwareLicenseType entity)
        {
            Name = Guard.Against.NullOrEmpty(entity.Name, nameof(entity.Name));
        }
    }
}
