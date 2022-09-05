using IToNeo.ApplicationCore.Entities;
using System;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class EquipmentWriteOffUpdate
    {
        private readonly string _testName = "TestName";
        private readonly DateTime _testDate = DateTime.Now;
        private readonly float _testLiquidationValue = 1.22f;
        private readonly string _testNote = "TestNote";
        private readonly string _testEquipmentId = Guid.NewGuid().ToString();

        [Fact]
        public void UpdateEquipmentWriteOff()
        {
            var equipmentEquipmentWriteOff = new EquipmentWriteOff()
            {
                Name = _testName,
                Date = _testDate,
                LiquidationValue = _testLiquidationValue,
                Note = _testNote,
                EquipmentId = _testEquipmentId,
            };

            var updatebleEquipmentWriteOff = new EquipmentWriteOff();
            updatebleEquipmentWriteOff.Update(equipmentEquipmentWriteOff);

            Assert.Equal(_testName, updatebleEquipmentWriteOff.Name);
            Assert.Equal(_testDate, updatebleEquipmentWriteOff.Date);
            Assert.Equal(_testLiquidationValue, updatebleEquipmentWriteOff.LiquidationValue);
            Assert.Equal(_testNote, updatebleEquipmentWriteOff.Note);
            Assert.Equal(_testEquipmentId, updatebleEquipmentWriteOff.EquipmentId);

        }
    }
}
