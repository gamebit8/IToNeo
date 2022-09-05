using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class EquipmentTypeUpdate
    {
        private readonly string _testName = "TestName";

        [Fact]
        public void UpdateEquipmentType()
        {
            var equipmentType = new EquipmentType()
            {
                Name = _testName,
            };

            var updatebleEquipmentType = new EquipmentType();
            updatebleEquipmentType.Update(equipmentType);

            Assert.Equal(_testName, updatebleEquipmentType.Name);
        }
    }
}
