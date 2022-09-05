using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace IToNeo.ApplicationCore.Entities.SoftwareAggregate
{
    public class Software : BaseEntity, IUpdateEntity<Software>
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public string DeveloperId { get; set; }
        public virtual SoftwareDeveloper Developer { get; set; } 
        public virtual ICollection<SoftwareLicense> Licenses { get; set; } = new HashSet<SoftwareLicense>();

        public Software() { }
        public Software(string name, string note, string developerId)
        {
            Name = name;
            Note = note;
            DeveloperId = developerId;
        }

        public void Update(Software entity)
        {
            Name = Guard.Against.NullOrEmpty(entity.Name, nameof(entity.Name));
            DeveloperId = Guard.Against.Null(entity.DeveloperId, nameof(entity.DeveloperId));
            Note = entity.Note;
        }
    }
}
