using IToNeo.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class EmployeeUpdate
    {
        private readonly string _testFirstName = "TestName";
        private readonly string _testLastName = "TestLastName";
        private readonly string _testPatronymicName = "TestPatronymicName";
        private readonly string _testOrganizationId = Guid.NewGuid().ToString();
        private readonly string _testDepartment = "TestDepartment";
        private readonly string _testPosition = "TestPosition";
        private readonly string _testUsername = "TestUsername";
        
        [Fact]
        public void UpdateEmployee()
        {
            var employee = new Employee()
            {
                FirstName = _testFirstName,
                LastName = _testLastName,
                PatronymicName = _testPatronymicName,
                OrganizationId = _testOrganizationId,
                Department = _testDepartment,
                Position = _testPosition,
                Username = _testUsername,
            };

            var updatebleEmployee = new Employee();
            updatebleEmployee.Update(employee);

            Assert.Equal(_testFirstName, updatebleEmployee.FirstName);
            Assert.Equal(_testLastName, updatebleEmployee.LastName);
            Assert.Equal(_testPatronymicName, updatebleEmployee.PatronymicName);
            Assert.Equal(_testDepartment, updatebleEmployee.Department);
            Assert.Equal(_testPosition, updatebleEmployee.Position);
            Assert.Equal(_testUsername, updatebleEmployee.Username);
        }
    }
}
