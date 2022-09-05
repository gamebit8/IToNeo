using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Interfaces;
using System;

namespace IToNeo.ApplicationCore.Entities
{
    public class EquipmentWriteOff : BaseEntity, IUpdateEntity<EquipmentWriteOff>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public float LiquidationValue { get; set; }
        public string Note { get; set; }
        public string EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        public EquipmentWriteOff() { }
        public EquipmentWriteOff(string name, DateTime date, float liquidationValue, string note, string equipmentId)
        {
            Date = date;
            LiquidationValue = liquidationValue;
            Note = note;
            EquipmentId = equipmentId;
            Name = name;
        }

        public void Update(EquipmentWriteOff writeOff) 
        {
            Date = Guard.Against.OutOfSQLDateRange(writeOff.Date, nameof(writeOff.Date));
            LiquidationValue = Guard.Against.NegativeOrZero(writeOff.LiquidationValue, nameof(writeOff.LiquidationValue));
            Note = writeOff.Note;
            EquipmentId = Guard.Against.Null(writeOff.EquipmentId, nameof(writeOff.EquipmentId));
            Name = Guard.Against.NullOrEmpty(writeOff.Name, nameof(writeOff.Name));
        }
    }
}
