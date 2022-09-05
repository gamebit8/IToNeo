using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IToNeo.IntegrationTests.Repositories.EquipmentRepository
{
    public class Update
    {
        private readonly IToNeoContext _context;
        private readonly EfReadOnlyRepository<Equipment> _repository;
        private readonly List<Equipment> _equipment = new EquipmentsBuilder().Build().ToList();
        private readonly string _testName = "TestName";
        private readonly string _testTypeId = Guid.NewGuid().ToString();
        private readonly string _testOrganizationId = Guid.NewGuid().ToString();
        private readonly string _testStatusId = Guid.NewGuid().ToString();
        private readonly string _testPlaceId = Guid.NewGuid().ToString();
        private readonly string _testEmployeeId = Guid.NewGuid().ToString();
        private readonly string _testSerialNumber = "TestSerialNumber";
        private readonly string _testNote = "TestNote";
        private readonly DateTime _testDateOfInstallation = DateTime.Now;
        public Update()
        {
            var dbOption = new DbContextOptionsBuilder<IToNeoContext>()
                .UseInMemoryDatabase(databaseName: "UpdateTestDB")
                .Options;

            _context = new IToNeoContext(dbOption);
            _repository = new EfRepository<Equipment>(_context);
        }

        [Fact]
        public async Task UpdateEquipment()
        {
            var newEquipment = new Equipment()
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

            await _context.AddRangeAsync(_equipment);
            await _context.SaveChangesAsync();

            var updatebleEquipment = await _context.Equipments.FirstOrDefaultAsync() ;
            updatebleEquipment.Update(newEquipment);

            var updatebleEquipmentAfterUpdateFromRepository = await _repository.GetByIdAsync(updatebleEquipment.Id);

            Assert.NotNull(updatebleEquipment);
            Assert.NotNull(updatebleEquipmentAfterUpdateFromRepository);
            Assert.Equal(updatebleEquipment, updatebleEquipmentAfterUpdateFromRepository);
            Assert.Equal(_testName, updatebleEquipmentAfterUpdateFromRepository.Name);
            Assert.Equal(_testTypeId, updatebleEquipmentAfterUpdateFromRepository.TypeId);
            Assert.Equal(_testOrganizationId, updatebleEquipmentAfterUpdateFromRepository.OrganizationId);
            Assert.Equal(_testStatusId, updatebleEquipmentAfterUpdateFromRepository.StatusId);
            Assert.Equal(_testEmployeeId, updatebleEquipmentAfterUpdateFromRepository.EmployeeId);
            Assert.Equal(_testNote, updatebleEquipmentAfterUpdateFromRepository.Note);
            Assert.Equal(_testDateOfInstallation, updatebleEquipmentAfterUpdateFromRepository.DateOfInstallation);
        }
    }
}
