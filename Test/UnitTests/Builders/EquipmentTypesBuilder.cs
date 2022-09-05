using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using System.Collections.Generic;

namespace IToNeo.UnitTests.Builders
{
    public class EquipmentTypesBuilder
    {
        private readonly IEnumerable<EquipmentType> _types;

        public EquipmentTypesBuilder()
        {
            _types = WithDefaultValues();
        }

        private static IEnumerable<EquipmentType> WithDefaultValues()
        {
            return new List<EquipmentType>()
            {
                new EquipmentType("IP телефон"),
                new EquipmentType("ИБП"),
                new EquipmentType("Монитор"),
                new EquipmentType("Компьютер"),
                new EquipmentType("Ноутбук")
            };
        }

        public IEnumerable<EquipmentType> Build() => _types;
    }
}
