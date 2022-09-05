using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System.Linq;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class EquipmentTypeWithSpecification
    {
        private readonly IQueryable<EquipmentType> _testEquipmentTypes;

        public EquipmentTypeWithSpecification()
        {
            _testEquipmentTypes = new EquipmentTypesBuilder().Build().AsQueryable();
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 100, 5)]
        [InlineData(1, 100, 4)]
        public void ReturnEquipmentTypesWithFilter(int skip, int take, int count)
        {
            var spec = new IToNeo.ApplicationCore.Specifications.EquipmentTypeWithSpecification(skip, take, new EquipmentType());
            var result = SpecificationEvaluator<EquipmentType>.GetQuery(_testEquipmentTypes, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }

        [Fact]
        public void ReturnEquipmentTypeWithFilter()
        {
            var equipmentTypeAsFilter = _testEquipmentTypes.First();

            var spec = new IToNeo.ApplicationCore.Specifications.EquipmentTypeWithSpecification(0, 100, equipmentTypeAsFilter);
            var result = SpecificationEvaluator<EquipmentType>.GetQuery(_testEquipmentTypes, spec).ToList();

            Assert.Single(result);
            Assert.Equal(equipmentTypeAsFilter, result.First());
        }
    }
}
