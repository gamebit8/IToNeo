using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IToNeo.IntegrationTests.Repositories.EquipmentRepository
{
    public class Add
    {
        private readonly IToNeoContext _context;
        private readonly EfRepository<Equipment> _repository;
        private readonly List<Equipment> _equipment = new EquipmentsBuilder().Build().ToList();
        public Add()
        {
            var dbOption = new DbContextOptionsBuilder<IToNeoContext>()
                .UseInMemoryDatabase(databaseName: "AddTestDB")
                .Options;

            _context = new IToNeoContext(dbOption);
            _repository = new EfRepository<Equipment>(_context);
        }

        [Fact]
        public async Task AddEquipment()
        {
            var equipmentsCount = _equipment.Count();
            var preConfigEquipments = _equipment.TakeLast(equipmentsCount - 1);
            var addableEquipment = _equipment.FirstOrDefault();

            await _context.AddRangeAsync(preConfigEquipments);
            await _context.SaveChangesAsync();

            await _repository.AddAsync(addableEquipment);
            var addableEquipmentFromRepository = await _repository.GetByIdAsync(addableEquipment.Id);

            Assert.NotNull(addableEquipmentFromRepository);
            Assert.Equal(addableEquipment, addableEquipmentFromRepository);
        }
    }
}
