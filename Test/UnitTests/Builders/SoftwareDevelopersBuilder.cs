using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using System.Collections.Generic;

namespace UnitTests.Builders
{
    public class SoftwareDevelopersBuilder
    {
        private readonly IEnumerable<SoftwareDeveloper> _developers;

        public SoftwareDevelopersBuilder()
        {
            _developers = WithDefaultValues();
        }

        private static IEnumerable<SoftwareDeveloper> WithDefaultValues()
        {
            return new List<SoftwareDeveloper>()
            {
                new SoftwareDeveloper("Microsoft"),
                new SoftwareDeveloper("1c")
            };
        }

        public IEnumerable<SoftwareDeveloper> Build() => _developers;
    }
}
