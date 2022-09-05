using IToNeo.ApplicationCore.Entities;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class PlaceUpdate
    {
        private readonly string _testName = "TestName";
        private readonly string _testAddress = "TestAddress";

        [Fact]
        public void UpdateOrganization()
        {
            var place = new Place()
            {
                Name = _testName,
                Address = _testAddress
            };

            var updateblePlace = new Place();
            updateblePlace.Update(place);

            Assert.Equal(_testName, updateblePlace.Name);
            Assert.Equal(_testAddress, updateblePlace.Address);
        }
    }
}
