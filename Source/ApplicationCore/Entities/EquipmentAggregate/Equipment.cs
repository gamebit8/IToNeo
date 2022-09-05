using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace IToNeo.ApplicationCore.Entities.EquipmentAggregate
{
    public class Equipment : BaseEntity, IUpdateEntity<Equipment>
    {
        public string Name { get; set; }
        public string TypeId { get; set; }
        public string OrganizationId { get; set; }
        public string StatusId { get; set; }
        public string PlaceId { get; set; }
        public string EmployeeId { get; set; }
        public string InventoryNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Note { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public DateTime? DateOfInstallation { get; set; }
        public virtual Place Place { get; set; }
        public virtual EquipmentStatus Status { get; set; }
        public virtual EquipmentType Type { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual FileEntity File { get; set; }
        public virtual EquipmentWriteOff WriteOff { get; set; }
        public virtual EquipmentDisposal Disposal { get; set; }
        public virtual ICollection<SoftwareLicense> SoftwareLicenses { get; set; } = new HashSet<SoftwareLicense>();
        public virtual ICollection<EquipmentSoftwareLicense> EquipmentSoftwareLicences { get; set; } = 
            new HashSet<EquipmentSoftwareLicense>();

        public Equipment() { }

        public Equipment(string name, string typeId, string orgId, string statusId,
            string placeId, string employeeId, string inventoryNumber, string serialNumber, 
            string note)
        {
            Name = name;
            TypeId = typeId;
            OrganizationId = orgId;
            StatusId = statusId;
            PlaceId = placeId;
            EmployeeId = employeeId;
            InventoryNumber = null;
            SerialNumber = serialNumber;
            Note = note;
        }

        public void Update (Equipment equipment)
        {
            Name = Guard.Against.NullOrEmpty(equipment.Name, nameof(equipment.Name));
            TypeId = Guard.Against.Null(equipment.TypeId, nameof(equipment.TypeId));
            OrganizationId = Guard.Against.Null(equipment.OrganizationId, nameof(equipment.OrganizationId));
            StatusId = Guard.Against.Null(equipment.StatusId, nameof(equipment.StatusId));
            PlaceId = Guard.Against.Null(equipment.PlaceId, nameof(equipment.PlaceId));
            EmployeeId = Guard.Against.Null(equipment.EmployeeId, nameof(equipment.EmployeeId));
            SerialNumber = Guard.Against.NullOrEmpty(equipment.SerialNumber, nameof(equipment.SerialNumber)); 
            Note = Guard.Against.NullOrEmpty(equipment.Note, nameof(equipment.Note));
            DateOfInstallation = equipment.DateOfInstallation;
        }
    }
}
