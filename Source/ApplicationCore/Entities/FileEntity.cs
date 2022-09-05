using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace IToNeo.ApplicationCore.Entities
{
    public class FileEntity : BaseEntity, IUpdateEntity<FileEntity>
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public string EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string SoftwareLicenseId { get; set; }
        public SoftwareLicense SoftwareLicense { get; set; }
        public FileEntity() { }
        public FileEntity(string name, byte[] content, string equipmentId, string employeeId, string softwareLicenseId)
        {
            Name = name ?? throw new System.ArgumentNullException(nameof(employeeId));
            Content = content ?? throw new System.ArgumentNullException(nameof(employeeId));
            EquipmentId = equipmentId;
            EmployeeId = employeeId;
            SoftwareLicenseId = softwareLicenseId;
        }
        public void Update(FileEntity file)
        {
            Name = Guard.Against.NullOrEmpty(file.Name, nameof(file.Name));
            Content = Guard.Against.Null(file.Content, nameof(file.Content));
        }
    }
}