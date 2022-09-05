using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class SoftwareDeveloperUpdate
    {
        private readonly string _testName = "TestName";

        [Fact]
        public void UpdateSoftwareDeveloper()
        {
            var softwareDeveloper = new SoftwareDeveloper()
            {
                Name = _testName,
            };

            var updatebleSoftwareDeveloper = new SoftwareDeveloper();
            updatebleSoftwareDeveloper.Update(softwareDeveloper);

            Assert.Equal(_testName, updatebleSoftwareDeveloper.Name);
        }
    }
}
