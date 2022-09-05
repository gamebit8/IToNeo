using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using System;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class SoftwareLicenseUpdate
    {
        private readonly string _testName = "TestName";
        private readonly string _testTypeId = Guid.NewGuid().ToString();
        private readonly int _testCount = 2;
        private readonly string _testLicenseCode = "TestLicenseCode";
        private readonly string _testSoftwareId = Guid.NewGuid().ToString();
        private readonly string _testNote = "TestNote";
        private readonly string _testOrganizationId = Guid.NewGuid().ToString();


        [Fact]
        public void UpdateSoftwareLicense()
        {
            var softwareLicense = new SoftwareLicense()
            {
                Name = _testName,
                TypeId = _testTypeId,
                Count = _testCount,
                LicenseCode = _testLicenseCode,
                SoftwareId = _testSoftwareId,
                Note = _testNote,
                OrganizationId = _testOrganizationId,
            };

            var updatebleSoftwareLicense = new SoftwareLicense();
            updatebleSoftwareLicense.Update(softwareLicense);

            Assert.Equal(_testName, updatebleSoftwareLicense.Name);
            Assert.Equal(_testTypeId, updatebleSoftwareLicense.TypeId);
            Assert.Equal(_testCount, updatebleSoftwareLicense.Count);
            Assert.Equal(_testSoftwareId, updatebleSoftwareLicense.SoftwareId);
            Assert.Equal(_testOrganizationId, updatebleSoftwareLicense.OrganizationId);
            Assert.Equal(_testNote, updatebleSoftwareLicense.Note);
        }
    }
}
