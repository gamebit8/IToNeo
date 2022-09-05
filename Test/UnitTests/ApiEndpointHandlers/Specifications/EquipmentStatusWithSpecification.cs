using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class EquipmentStatusWithSpecification
    {
        private readonly IQueryable<EquipmentStatus> _testEquipmentStatuses;

        public EquipmentStatusWithSpecification()
        {
            _testEquipmentStatuses = new EquipmentStatusesBuilder().Build().AsQueryable();
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 100, 4)]
        [InlineData(1, 100, 3)]
        public void ReturnEquipmentStatusesWithFilter(int skip, int take, int count)
        {
            var spec = new IToNeo.ApplicationCore.Specifications.EquipmentStatusWithSpecification(skip, take, new EquipmentStatus());
            var result = SpecificationEvaluator<EquipmentStatus>.GetQuery(_testEquipmentStatuses, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }

        [Fact]
        public void ReturnEquipmentStatusWithFilter()
        {
            var equipmentStatusAsFilter = _testEquipmentStatuses.First();

            var spec = new IToNeo.ApplicationCore.Specifications.EquipmentStatusWithSpecification(0, 100, equipmentStatusAsFilter);
            var result = SpecificationEvaluator<EquipmentStatus>.GetQuery(_testEquipmentStatuses, spec).ToList();

            Assert.Single(result);
            Assert.Equal(equipmentStatusAsFilter, result.First());
        }
    }
}
