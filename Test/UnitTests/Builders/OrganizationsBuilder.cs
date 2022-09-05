using IToNeo.ApplicationCore.Entities;
using System.Collections.Generic;

namespace IToNeo.UnitTests.Builders
{
    public class OrganizationsBuilder
    {
        private readonly IEnumerable<Organization> _organizations;

        public OrganizationsBuilder()
        {
            _organizations = WithDefaultValues();
        }

        private static IEnumerable<Organization> WithDefaultValues()
        {
            return new List<Organization>()
            {
                new Organization("ООО Рустех"),
                new Organization("ОАО ГосКом"),
                new Organization("ООО ГорГос")
            };
        }

        public IEnumerable<Organization> Build() => _organizations;
    }
}
