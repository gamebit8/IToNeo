using IToNeo.ApplicationCore.Entities;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class OrganizationUpdate
    {
        private readonly string _testName = "TestName";

        [Fact]
        public void UpdateOrganization()
        {
            var organization = new Organization()
            {
                Name = _testName,
            };

            var updatebleOrganization = new Organization();
            updatebleOrganization.Update(organization);

            Assert.Equal(_testName, updatebleOrganization.Name);
        }
    }
}
