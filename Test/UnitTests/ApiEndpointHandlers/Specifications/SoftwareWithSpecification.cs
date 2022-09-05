using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System.Linq;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class SoftwareWithSpecification
    {
        private readonly IQueryable<Software> _testSoftwares;

        public SoftwareWithSpecification()
        {
            _testSoftwares = new SoftwaresBuilder().Build().AsQueryable();
        }

        [Theory]
        [InlineData("Office Professional 2016", null, null, 0, 100, 1)]
        [InlineData(null, "тест комментария", null, 0, 100, 5)]
        [InlineData(null, null, "1", 0, 100, 3)]
        [InlineData(null, null, "0", 0, 100, 2)]
        [InlineData(null, null, null, 0, 1, 1)]
        [InlineData(null, null, null, 0, 100, 5)]
        [InlineData(null, null, null, 1, 100, 4)]
        public void ReturnSoftwaresWithFilter(string name, string note, string developerId, int skip, int take, int count)
        {
            var softwareAsFilter = new Software()
            {
                Name = name,
                Note = note,
                DeveloperId = developerId,
            };

            var spec = new IToNeo.ApplicationCore.Specifications.SoftwareWithSpecification(skip, take, softwareAsFilter);
            var result = SpecificationEvaluator<Software>.GetQuery(_testSoftwares, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }

        [Fact]
        public void ReturnSoftwareLicenseWithFilter()
        {
            var softwareAsFilter = _testSoftwares.First();

            var spec = new IToNeo.ApplicationCore.Specifications.SoftwareWithSpecification(0, 100, softwareAsFilter);
            var result = SpecificationEvaluator<Software>.GetQuery(_testSoftwares, spec).ToList();

            Assert.Single(result);
            Assert.Equal(softwareAsFilter, result.First());
        }
    }
}
