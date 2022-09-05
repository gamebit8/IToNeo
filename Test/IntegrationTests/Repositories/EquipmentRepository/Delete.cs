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
    public class Delete
    {
        private readonly IToNeoContext _context;
        private readonly EfRepository<Equipment> _repository;
        private readonly List<Equipment> _equipment = new EquipmentsBuilder().Build().ToList();
        public Delete()
        {
            var dbOption = new DbContextOptionsBuilder<IToNeoContext>()
                .UseInMemoryDatabase(databaseName: "DeleteTestDB")
                .Options;

            _context = new IToNeoContext(dbOption);
            _repository = new EfRepository<Equipment>(_context);
        }

        [Fact]
        public async Task DeleteEquipment()
        {
            await _context.AddRangeAsync(_equipment);
            await _context.SaveChangesAsync();

            var deletableEquipment = await _context.Equipments.FirstOrDefaultAsync();
            await _repository.DeleteAsync(deletableEquipment);

            var deletableEquipmentAfterDelete = await _context.Equipments.FindAsync(deletableEquipment.Id);

            Assert.NotNull(deletableEquipment);
            Assert.Null(deletableEquipmentAfterDelete);
        }
    }
}

