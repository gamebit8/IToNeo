using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class SoftwareUpdate
    {
        private readonly string _testName = "TestName";
        private readonly string _testNote = "TestNote";
        private readonly string _testDeveloperId = Guid.NewGuid().ToString();

        [Fact]
        public void UpdateSoftware()
        {
            var software = new Software()
            {
                Name = _testName,
                DeveloperId = _testDeveloperId,
                Note = _testNote
            };

            var updatebleSoftware = new Software();
            updatebleSoftware.Update(software);

            Assert.Equal(_testName, updatebleSoftware.Name);
            Assert.Equal(_testNote, updatebleSoftware.Note);
            Assert.Equal(_testDeveloperId, updatebleSoftware.DeveloperId);
        }
    }
}
