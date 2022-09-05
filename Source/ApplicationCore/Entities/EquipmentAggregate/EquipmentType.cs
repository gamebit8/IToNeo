using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace IToNeo.ApplicationCore.Entities.EquipmentAggregate
{
    public class EquipmentType : BaseEntity, IUpdateEntity<EquipmentType>
    { 
        public string Name { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; } = new HashSet<Equipment>();

        public EquipmentType() { }
        public EquipmentType(string name)
        {
            Name = name;
        }

        public void Update(EquipmentType type)
        {
            Name = Guard.Against.NullOrEmpty(type.Name, nameof(type.Name));
        }
    }
}
