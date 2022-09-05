using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class SoftwareLicenseTypeUpdate
    {
        private readonly string _testName = "TestName";

        [Fact]
        public void UpdateSoftwareLicenseType()
        {
            var softwareLicenseType = new SoftwareLicenseType()
            {
                Name = _testName,
            };

            var updatebleSoftwareLicenseType = new SoftwareLicenseType();
            updatebleSoftwareLicenseType.Update(softwareLicenseType);

            Assert.Equal(_testName, updatebleSoftwareLicenseType.Name);
        }
    }
}
