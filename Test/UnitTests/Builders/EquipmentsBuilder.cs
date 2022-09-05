using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using System.Collections.Generic;

namespace IToNeo.UnitTests.Builders
{
    public class EquipmentsBuilder
    {
        private readonly IEnumerable<Equipment> _equipments;

        public EquipmentsBuilder()
        {
            _equipments = WithDefaultValues();
        }

        private static IEnumerable<Equipment> WithDefaultValues()
        {
            return new List<Equipment>()
            {
                new Equipment("HP ProDesk 400 G7", "0", "0", "0",
                    "0", "0", "20-0001-01", "AAA11","Тест"),
                new Equipment("HP EliteDisplay E24", "1", "0", "0",
                    "0",  "0", "20-0001-02", "AAA12","Тест"),
                new Equipment("APC Back-UPS 500 ВА", "2", "0", "0",
                    "0", "0", "20-0001-03", "AAA13","Тест"),
                new Equipment("Fanvil X3S", "3", "0", "0",
                   "0", "0", "20-0001-04", "AAA14","Тест"),
                new Equipment("HP ProDesk 400 G7", "0", "1", "0",
                   "1", "1", "20-0002-01", "AAA21","Тест"),
                new Equipment("HP EliteDisplay E24", "1","1", "0",
                    "1", "1", "20-0002-02", "AAA22","Тест"),
                new Equipment("APC Back-UPS 500 ВА", "2", "1", "0",
                    "1", "1", "20-0002-03", "AAA24","Тест"),
                new Equipment("Fanvil X3S", "3", "1", "0",
                    "1", "1", "20-0002-04", "AAA24","Тест"),
                new Equipment("HP ProDesk 400 G7", "0", "2", "0",
                    "2", "2", "20-0003-01", "AAA31","Тест"),
                new Equipment("HP EliteDisplay E24", "1", "2", "0",
                    "2", "2", "20-0003-02", "AAA32","Тест"),
                new Equipment("APC Back-UPS 500 ВА", "2", "2", "0",
                    "2","2", "20-0003-03", "AAA34","Тест"),
                new Equipment("Fanvil X3S", "3", "2", "0",
                    "2", "2", "20-0003-04", "AAA34","Тест"),
                new Equipment("HP ProBook 440 G7", "4", "0", "1",
                    "2", "2", "20-0004-01", "AAA41","Тест"),
                new Equipment("HP ProBook 440 G7", "4", "1", "2",
                    "2","2", "20-0004-02", "AAA42","Тест"),
                new Equipment("HP ProBook 440 G7", "4", "2", "3",
                    "2", "2", "20-0004-03", "AAA43","Тест"),
            };
        }

        public IEnumerable<Equipment> Build() => _equipments;
    }
}
