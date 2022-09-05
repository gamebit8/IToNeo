using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace IToNeo.ApplicationCore.Entities.EquipmentAggregate
{
    public class EquipmentStatus : BaseEntity, IUpdateEntity<EquipmentStatus>
    {
        public string Name { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; } = new HashSet<Equipment>();
        public EquipmentStatus() { }

        public EquipmentStatus(string name)
        {
            Name = name;
        }

        public void Update(EquipmentStatus status)
        {
            Name = Guard.Against.NullOrEmpty(status.Name, nameof(status.Name));
        }
    }
}
