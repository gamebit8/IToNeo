using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class EquipmentStatusUpdate
    {
        private readonly string _testName = "TestName";

        [Fact]
        public void UpdateEquipmentStatus()
        {
            var equipmentStatus = new EquipmentStatus()
            {
                Name = _testName,
            };

            var updatebleEquipmentStatus = new EquipmentStatus();
            updatebleEquipmentStatus.Update(equipmentStatus);

            Assert.Equal(_testName, updatebleEquipmentStatus.Name);
        }
    }
}
