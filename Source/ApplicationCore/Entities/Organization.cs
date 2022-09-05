using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace IToNeo.ApplicationCore.Entities
{
    public class Organization : BaseEntity, IUpdateEntity<Organization>
    {
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public virtual ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
        public virtual ICollection<SoftwareLicense> SoftwareLicense { get; set; } = new List<SoftwareLicense>();

        public Organization() { }
        public Organization(string name)
        {
            Name = name;
        }

        public void Update(Organization organization) 
        {
            Name = Guard.Against.NullOrEmpty(organization.Name, nameof(organization.Name));
        }
    }
}
