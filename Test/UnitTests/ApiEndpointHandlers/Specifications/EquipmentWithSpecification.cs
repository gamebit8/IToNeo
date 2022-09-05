using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class EquipmentWithSpecification
    {
        private readonly IQueryable<Equipment> _testEquipments;

        public EquipmentWithSpecification()
        {
            _testEquipments = new EquipmentsBuilder().Build().AsQueryable();
        }

        [Fact]
        public void ReturnEquipmentsWithFilter()
        {
            var equipmentAsFilter = _testEquipments.First();

            var spec = new IToNeo.ApplicationCore.Specifications.EquipmentWithSpecification(0, 100, equipmentAsFilter);
            var result = SpecificationEvaluator<Equipment>.GetQuery(_testEquipments, spec).ToList();

            Assert.Single(result);
            Assert.Equal(equipmentAsFilter, result.First());
        }

        [Theory]

        [InlineData("0", null, null, null, null, 0, 100, 3)]
        [InlineData(null, "0", null, null, null, 0, 100, 5)]
        [InlineData(null, null, "0", null, null, 0, 100, 12)]
        [InlineData(null, null, null, "0", null, 0, 100, 4)]
        [InlineData(null, null, null, null, "0", 0, 100, 4)]
        [InlineData(null, null, null, null, null, 0, 100, 15)]
        [InlineData(null, null, null, null, null, 0, 1, 1)]
        [InlineData(null, null, null, null, null, 1, 100, 14)]
        public void ReturnEquipmentWithFilter(
            string typeId, string orgId, string statusId, string placeId, string employeeId, int skip, int take, int count)
        {
            var equipmentAsFilter = new Equipment()
            {
                TypeId = typeId,
                OrganizationId = orgId,
                StatusId = statusId,
                PlaceId = placeId,
                EmployeeId = employeeId,
            };
            var spec = new IToNeo.ApplicationCore.Specifications.EquipmentWithSpecification(skip, take, equipmentAsFilter);
            var result = SpecificationEvaluator<Equipment>.GetQuery(_testEquipments, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }
    }
}
