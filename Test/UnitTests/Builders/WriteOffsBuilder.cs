using IToNeo.ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace IToNeo.UnitTests.Builders
{
    public class WriteOffsBuilder
    {
        private readonly IEnumerable<EquipmentWriteOff> _writeOffs;

        public WriteOffsBuilder()
        {
            _writeOffs = WithDefaultValues();
        }

        private static IEnumerable<EquipmentWriteOff> WithDefaultValues()
        {
            return new List<EquipmentWriteOff>()
            {
                new EquipmentWriteOff("1/1", DateTime.Now.Date, (float)0.01, "test1", "0"),
                new EquipmentWriteOff("1/2", DateTime.Now.Date, (float)0.02, "test2", "1"),
            };
        }

        public IEnumerable<EquipmentWriteOff> Build() => _writeOffs;
    }
}
