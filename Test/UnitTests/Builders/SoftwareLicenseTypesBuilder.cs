using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using System.Collections.Generic;

namespace IToNeo.UnitTests.Builders
{
    public class SoftwareLicenseTypesBuilder
    {
        private readonly IEnumerable<SoftwareLicenseType> _types;

        public SoftwareLicenseTypesBuilder()
        {
            _types = WithDefaultValues();
        }

        private static IEnumerable<SoftwareLicenseType> WithDefaultValues()
        {
            return new List<SoftwareLicenseType>()
            {
                new SoftwareLicenseType("oem"),
                new SoftwareLicenseType("box")
            };
        }

        public IEnumerable<SoftwareLicenseType> Build() => _types;
    }
}
