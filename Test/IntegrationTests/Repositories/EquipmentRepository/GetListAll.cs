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
    public class GetListAll
    {
        private readonly IToNeoContext _context;
        private readonly EfReadOnlyRepository<Equipment> _repository;
        private readonly List<Equipment> _equipment = new EquipmentsBuilder().Build().ToList();
        public GetListAll()
        {
            var dbOption = new DbContextOptionsBuilder<IToNeoContext>()
                .UseInMemoryDatabase(databaseName: "GetListAllTestDB")
                .Options;

            _context = new IToNeoContext(dbOption);
            _repository = new EfRepository<Equipment>(_context);
        }

        [Fact]
        public async Task GetListAllEquipment()
        {
            await _context.AddRangeAsync(_equipment);
            await _context.SaveChangesAsync();

            var getableEquipments = await _context.Equipments.ToListAsync();
            var getableEquipmentsFromRepository = await _repository.ListAllAsync();

            Assert.NotNull(getableEquipments);
            Assert.NotNull(getableEquipmentsFromRepository);
            Assert.Equal(15, getableEquipmentsFromRepository.Count);
        }
    }
}
