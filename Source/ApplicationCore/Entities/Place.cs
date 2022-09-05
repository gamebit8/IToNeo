using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using System.Collections.Generic;
using IToNeo.ApplicationCore.Interfaces;

namespace IToNeo.ApplicationCore.Entities
{
    public class Place : BaseEntity, IUpdateEntity<Place>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();
        public Place() { }
        
        public Place(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public void Update(Place place) 
        {
            Name = Guard.Against.NullOrEmpty(place.Name, nameof(place.Name));
            Address = Guard.Against.NullOrEmpty(place.Address, nameof(place.Address));
        }
    }

}
