using IToNeo.ApplicationCore.Entities;
using System.Collections.Generic;

namespace IToNeo.UnitTests.Builders
{
    public class EquipmentsSoftwareLicensesBuilder
    {
        private readonly IEnumerable<EquipmentSoftwareLicense> _equipmentsLicenses;

        public EquipmentsSoftwareLicensesBuilder()
        {
            _equipmentsLicenses = WithDefaultValues();
        }

        private static IEnumerable<EquipmentSoftwareLicense> WithDefaultValues()
        {
            return new List<EquipmentSoftwareLicense>()
            {
                new EquipmentSoftwareLicense("1", "1"),
                new EquipmentSoftwareLicense("1", "2"),
                new EquipmentSoftwareLicense("1", "3"),
                new EquipmentSoftwareLicense("2", "4"),
                new EquipmentSoftwareLicense("2", "2"),
                new EquipmentSoftwareLicense("2", "3"),
                new EquipmentSoftwareLicense("3", "5"),
                new EquipmentSoftwareLicense("3", "6")
            };
        }

        public IEnumerable<EquipmentSoftwareLicense> Build() => _equipmentsLicenses;
    }
}
