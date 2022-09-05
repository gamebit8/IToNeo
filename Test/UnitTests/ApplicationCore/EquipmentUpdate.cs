using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using System;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class EquipmentUpdate
    {
        private readonly string _testName = "TestName";
        private readonly string _testTypeId = Guid.NewGuid().ToString();
        private readonly string _testOrganizationId = Guid.NewGuid().ToString();
        private readonly string _testStatusId = Guid.NewGuid().ToString();
        private readonly string _testPlaceId = Guid.NewGuid().ToString();
        private readonly string _testEmployeeId = Guid.NewGuid().ToString();
        private readonly string _testSerialNumber = "TestSerialNumber";
        private readonly string _testNote = "TestNote";
        private readonly DateTime _testDateOfInstallation = DateTime.Now;

        [Fact]
        public void UpdateEquipment()
        {
            var equipment = new Equipment()
            {
                Name = _testName,
                TypeId = _testTypeId,
                OrganizationId = _testOrganizationId,
                StatusId = _testStatusId,
                PlaceId = _testPlaceId,
                EmployeeId = _testEmployeeId,
                SerialNumber = _testSerialNumber,
                Note = _testNote,
                DateOfInstallation = _testDateOfInstallation,
            };

            var updatebleEquipment = new Equipment();
            updatebleEquipment.Update(equipment);

            Assert.Equal(_testName, updatebleEquipment.Name);
            Assert.Equal(_testTypeId, updatebleEquipment.TypeId);
            Assert.Equal(_testOrganizationId, updatebleEquipment.OrganizationId);
            Assert.Equal(_testStatusId, updatebleEquipment.StatusId);
            Assert.Equal(_testEmployeeId, updatebleEquipment.EmployeeId);
            Assert.Equal(_testNote, updatebleEquipment.Note);
            Assert.Equal(_testDateOfInstallation, updatebleEquipment.DateOfInstallation);
        }
    }
}
