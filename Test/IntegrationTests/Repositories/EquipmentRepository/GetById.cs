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
    public class GetById
    {
        private readonly IToNeoContext _context;
        private readonly EfReadOnlyRepository<Equipment> _repository;
        private readonly List<Equipment> _equipment = new EquipmentsBuilder().Build().ToList();
        public GetById()
        {
            var dbOption = new DbContextOptionsBuilder<IToNeoContext>()
                .UseInMemoryDatabase(databaseName: "GetByIdTestDB")
                .Options;

            _context = new IToNeoContext(dbOption);
            _repository = new EfRepository<Equipment>(_context);
        }

        [Fact]
        public async Task GetByIdEquipment()
        {
            await _context.AddRangeAsync(_equipment);
            await _context.SaveChangesAsync();

            var getableEquipment = await _context.Equipments.FirstOrDefaultAsync();
            var getableEquipmentFromRepository = await _repository.GetByIdAsync(getableEquipment.Id);

            Assert.NotNull(getableEquipment);
            Assert.NotNull(getableEquipmentFromRepository);
            Assert.Equal(getableEquipment, getableEquipmentFromRepository);
        }
    }
}
