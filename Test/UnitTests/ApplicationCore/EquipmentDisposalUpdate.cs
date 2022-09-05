using IToNeo.ApplicationCore.Entities;
using System;
using Xunit;

namespace IToNeo.UnitTests.ApplicationCore
{
    public class EquipmentDisposalUpdate
    {
        private readonly string _testName = "TestName";
        private readonly DateTime _testDate = DateTime.Now;
        private readonly float _testResalePrice = 1.22F;
        private readonly string _testNote = "TestNote";
        private readonly string _testEquipmentId = Guid.NewGuid().ToString();

        [Fact]
        public void UpdateEquipmentDisposal()
        {
            var equipmentDisposal = new EquipmentDisposal()
            {
                Name = _testName,
                Date = _testDate,
                ResalePrice = _testResalePrice,
                Note = _testNote,
                EquipmentId = _testEquipmentId,
            };

            var updatebleEquipmentDisposal = new EquipmentDisposal();
            updatebleEquipmentDisposal.Update(equipmentDisposal);

            Assert.Equal(_testName, updatebleEquipmentDisposal.Name);
            Assert.Equal(_testDate, updatebleEquipmentDisposal.Date);
            Assert.Equal(_testResalePrice, updatebleEquipmentDisposal.ResalePrice);
            Assert.Equal(_testNote, updatebleEquipmentDisposal.Note);
            Assert.Equal(_testEquipmentId, updatebleEquipmentDisposal.EquipmentId);
        }
    }
}
