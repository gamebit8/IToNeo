using IToNeo.ApplicationCore.Entities;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class EquipmentSoftwareLicenseWithSpecification
    {
        private readonly IQueryable<EquipmentSoftwareLicense> _testEquipmentsSoftwareLicenses;

        public EquipmentSoftwareLicenseWithSpecification()
        {
            _testEquipmentsSoftwareLicenses = new EquipmentsSoftwareLicensesBuilder().Build().AsQueryable();
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 100, 8)]
        [InlineData(1, 100, 7)]
        public void ReturnEquipmentsSoftwareLicensesWithFilter(int skip, int take, int count)
        {
            var spec = new IToNeo.ApplicationCore.Specifications.EquipmentSoftwareLicenseWithSpecification(new EquipmentSoftwareLicense(), take, skip);
            var result = SpecificationEvaluator<EquipmentSoftwareLicense>.GetQuery(_testEquipmentsSoftwareLicenses, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }

        [Fact]
        public void ReturnEquipmentDisposalWithFilter()
        {
            var equipmentSoftwareLicenseAsFilter = _testEquipmentsSoftwareLicenses.First();

            var spec = new IToNeo.ApplicationCore.Specifications.EquipmentSoftwareLicenseWithSpecification(equipmentSoftwareLicenseAsFilter, 100, 0);
            var result = SpecificationEvaluator<EquipmentSoftwareLicense>.GetQuery(_testEquipmentsSoftwareLicenses, spec).ToList();

            Assert.Single(result);
            Assert.Equal(equipmentSoftwareLicenseAsFilter, result.First());
        }
    }
}
