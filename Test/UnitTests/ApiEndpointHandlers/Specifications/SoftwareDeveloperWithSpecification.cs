using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Builders;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class SoftwareDeveloperWithSpecification
    {
        private readonly IQueryable<SoftwareDeveloper> _testSoftwareDevelopers;

        public SoftwareDeveloperWithSpecification()
        {
            _testSoftwareDevelopers = new SoftwareDevelopersBuilder().Build().AsQueryable();
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(0, 100, 2)]
        [InlineData(1, 100, 1)]
        public void ReturnSoftwareDevelopersWithFilter(int skip, int take, int count)
        {
            var spec = new IToNeo.ApplicationCore.Specifications.SoftwareDeveloperWithSpecification(skip, take, new SoftwareDeveloper());
            var result = SpecificationEvaluator<SoftwareDeveloper>.GetQuery(_testSoftwareDevelopers, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }

        [Fact]
        public void ReturnSoftwareDeveloperLicenseWithFilter()
        {
            var developerAsFilter = _testSoftwareDevelopers.First();

            var spec = new IToNeo.ApplicationCore.Specifications.SoftwareDeveloperWithSpecification(0, 100, developerAsFilter);
            var result = SpecificationEvaluator<SoftwareDeveloper>.GetQuery(_testSoftwareDevelopers, spec).ToList();

            Assert.Single(result);
            Assert.Equal(developerAsFilter, result.First());
        }
    }
}
