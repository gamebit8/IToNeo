using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace IToNeo.ApplicationCore.Entities.SoftwareAggregate
{
    public class SoftwareDeveloper : BaseEntity, IUpdateEntity<SoftwareDeveloper>
    {
        public string Name { get; set; }
        public virtual ICollection<Software> Softwares { get; set; } = new HashSet<Software>();

        public SoftwareDeveloper() { }
        public SoftwareDeveloper(string name)
        {
            Name = name;
        }

        public void Update(SoftwareDeveloper entity)
        {
            Name = Guard.Against.NullOrEmpty(entity.Name, nameof(entity.Name));
        }
    }
}
