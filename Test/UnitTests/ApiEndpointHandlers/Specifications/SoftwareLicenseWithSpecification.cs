using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.Infrastructure.Data;
using IToNeo.UnitTests.Builders;
using System.Linq;
using Xunit;

namespace IToNeo.UnitTests.ApiEndpointHandlers.Specifications
{
    public class SoftwareLicenseWithSpecification
    {
        private readonly IQueryable<SoftwareLicense> _testSoftwareLicenses;

        public SoftwareLicenseWithSpecification()
        {
            _testSoftwareLicenses = new SoftwareLicensesBuilder().Build().AsQueryable();
        }

        [Theory]
        [InlineData("0", null, null, null, null, 0, 100, 4)]
        [InlineData(null, "XXX-XXX-XX1", null, null, null, 0, 100, 1)]
        [InlineData(null, null, null, "тест комментария", null, 0, 100, 6)]
        [InlineData(null, null, null, null, "0", 0, 100, 3)]
        [InlineData(null, null, null, null, null, 0, 1, 1)]
        [InlineData(null, null, null, null, null, 0, 100, 6)]
        [InlineData(null, null, null, null, null, 1, 100, 5)]
        public void ReturnSoftwareLicensesWithFilter(
            string typeId, string licenseCode, string softwareId, string note, string organizationId,int skip, int take, int count)
        {
            var licenseAsFilter = new SoftwareLicense()
            {
                TypeId = typeId,
                LicenseCode = licenseCode,
                SoftwareId = softwareId,
                Note = note,
                OrganizationId = organizationId,
            };

            var spec = new IToNeo.ApplicationCore.Specifications.SoftwareLicenseWithSpecification(skip, take, licenseAsFilter);
            var result = SpecificationEvaluator<SoftwareLicense>.GetQuery(_testSoftwareLicenses, spec).ToList();

            Assert.NotNull(result);
            Assert.Equal(count, result.Count);
        }

        [Fact]
        public void ReturnSoftwareLicenseLicenseWithFilter()
        {
            var licenseAsFilter = _testSoftwareLicenses.First();

            var spec = new IToNeo.ApplicationCore.Specifications.SoftwareLicenseWithSpecification(0, 100, licenseAsFilter);
            var result = SpecificationEvaluator<SoftwareLicense>.GetQuery(_testSoftwareLicenses, spec).ToList();

            Assert.Single(result);
            Assert.Equal(licenseAsFilter, result.First());
        }
    }
}
