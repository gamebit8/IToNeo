using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using System.Collections.Generic;

namespace IToNeo.UnitTests.Builders
{
    internal class EquipmentStatusesBuilder
    {
        private readonly IEnumerable<EquipmentStatus> _statuses;

        public EquipmentStatusesBuilder()
        {
            _statuses = WithDefaultValues();
        }

        private static IEnumerable<EquipmentStatus> WithDefaultValues()
        {
            return new List<EquipmentStatus>()
            {
                new EquipmentStatus("Используется"),
                new EquipmentStatus("На складе"),
                new EquipmentStatus("В ремонте"),
                new EquipmentStatus("Списано"),
            };
        }

        public IEnumerable<EquipmentStatus> Build() => _statuses;
    }
}

