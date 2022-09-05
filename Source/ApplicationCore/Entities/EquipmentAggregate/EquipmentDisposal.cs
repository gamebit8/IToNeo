using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Interfaces;
using System;

namespace IToNeo.ApplicationCore.Entities
{
    public class EquipmentDisposal : BaseEntity, IUpdateEntity<EquipmentDisposal>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public float ResalePrice { get; set; }
        public string Note { get; set; }
        public string EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        public EquipmentDisposal() { }
        public EquipmentDisposal(string name, DateTime date, float resalePrice, string note, string equipmentId)
        {
            Date = date;
            ResalePrice = resalePrice;
            Note = note;
            EquipmentId = equipmentId;
            Name = name;
        }

        public void Update(EquipmentDisposal disposal)
        {
            Name = Guard.Against.NullOrEmpty(disposal.Name, nameof(disposal.Name));
            Date = Guard.Against.OutOfSQLDateRange(disposal.Date, nameof(disposal.Date));
            ResalePrice = Guard.Against.NegativeOrZero(disposal.ResalePrice, nameof(disposal.ResalePrice));
            Note = disposal.Note;
            EquipmentId = Guard.Against.Null(disposal.EquipmentId, nameof(disposal.EquipmentId));
        }
    }
}
