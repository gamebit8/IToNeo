using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using System.Collections.Generic;

namespace IToNeo.UnitTests.Builders
{
    public class SoftwareLicensesBuilder
    {
        private readonly IEnumerable<SoftwareLicense> _licenses;

        public SoftwareLicensesBuilder()
        {
            _licenses = WithDefaultValues();
        }

        private static IEnumerable<SoftwareLicense> WithDefaultValues()
        {
            return new List<SoftwareLicense>()
            {
                new SoftwareLicense("0", 2, "XXX-XXX-XX1",
                    "4", "тест комментария", "0"),
                new SoftwareLicense("1", 2, "XXX-XXX-XX2",
                    "4", "тест комментария","0"),
                new SoftwareLicense("1", 2, "XXX-XXX-XX3",
                    "3", "тест комментария", "1"),
                new SoftwareLicense("0", 2, "XXX-XXX-XX4",
                    "2", "тест комментария", "2"),
                new SoftwareLicense("0", 1, "XXX-XXX-XX5",
                    "1", "тест комментария","1"),
                new SoftwareLicense("0", 1, "XXX-XXX-XX6",
                    "0", "тест комментария", "0")
            };
        }

        public IEnumerable<SoftwareLicense> Build() => _licenses;
    }
}
