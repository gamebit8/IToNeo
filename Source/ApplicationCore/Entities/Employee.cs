using Ardalis.GuardClauses;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace IToNeo.ApplicationCore.Entities
{
    public class Employee : BaseEntity, IUpdateEntity<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string Name { get; private set; }
        public string OrganizationId { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Username { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual FileEntity File { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; } = new List<Equipment>();

        public Employee() { }

        public Employee(string firstName, string lastName, string patronymicName, string login, string orgId, 
            string department, string @position)
        {
            FirstName = firstName;
            LastName = lastName;
            PatronymicName = patronymicName;
            OrganizationId = orgId;
            Department = department;
            Position = position;
        }

        public void Update(Employee employee) 
        {
            FirstName = Guard.Against.NullOrEmpty(employee.FirstName, nameof(employee.FirstName)); ;
            LastName = Guard.Against.NullOrEmpty(employee.LastName, nameof(employee.LastName)); ;
            PatronymicName = Guard.Against.NullOrEmpty(employee.PatronymicName, nameof(employee.PatronymicName));
            OrganizationId = Guard.Against.NullOrEmpty(employee.OrganizationId, nameof(employee.OrganizationId));
            Department = Guard.Against.NullOrEmpty(employee.Department, nameof(employee.Department));
            Position = Guard.Against.NullOrEmpty(employee.Position, nameof(employee.Position));
            Username = employee.Username;
        }
    }
}
