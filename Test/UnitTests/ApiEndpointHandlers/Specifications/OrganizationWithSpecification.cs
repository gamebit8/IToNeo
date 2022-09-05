using IToNeo.ApplicationCore.Entities;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System.Linq;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class OrganizationWithSpecification
    {
        private readonly IQueryable<Organization> _testOrganizations;

        public OrganizationWithSpecification()
        {
            _testOrganizations = new OrganizationsBuilder().Build().AsQueryable();
        }


        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 100, 3)]
        [InlineData(1, 100, 2)]
        public void ReturnOrganizationsWithFilter(int skip, int take, int count)
        {
            var spec = new IToNeo.ApplicationCore.Specifications.OrganizationWithSpecification(skip, take, new Organization());
            var result = SpecificationEvaluator<Organization>.GetQuery(_testOrganizations, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }

        [Fact]
        public void ReturOrganizationWithFilter()
        {
            var organizationAsFilter = _testOrganizations.First();

            var spec = new IToNeo.ApplicationCore.Specifications.OrganizationWithSpecification(0, 100, organizationAsFilter);
            var result = SpecificationEvaluator<Organization>.GetQuery(_testOrganizations, spec).ToList();

            Assert.Single(result);
            Assert.Equal(organizationAsFilter, result.First());
        }
    }
}
