using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System.Linq;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class SoftwareLicenseTypeWithSpecification
    {
        private readonly IQueryable<SoftwareLicenseType> _testSoftwareLicenseTypes;

        public SoftwareLicenseTypeWithSpecification()
        {
            _testSoftwareLicenseTypes = new SoftwareLicenseTypesBuilder().Build().AsQueryable();
        }


        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 100, 2)]
        [InlineData(1, 100, 1)]
        public void ReturnSoftwareLicenseTypesWithFilter(int skip, int take, int count)
        {
            var spec = new IToNeo.ApplicationCore.Specifications.SoftwareLicenseTypeWithSpecification(skip, take, new SoftwareLicenseType());
            var result = SpecificationEvaluator<SoftwareLicenseType>.GetQuery(_testSoftwareLicenseTypes, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }

        [Fact]
        public void ReturnSoftwareLicenseTypeLicenseWithFilter()
        {
            var typeAsFilter = _testSoftwareLicenseTypes.First();

            var spec = new IToNeo.ApplicationCore.Specifications.SoftwareLicenseTypeWithSpecification(0, 100, typeAsFilter);
            var result = SpecificationEvaluator<SoftwareLicenseType>.GetQuery(_testSoftwareLicenseTypes, spec).ToList();

            Assert.Single(result);
            Assert.Equal(typeAsFilter, result.First());
        }
    }
}
