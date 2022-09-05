using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.ApplicationCore.Helpers.Query;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IToNeo.ApplicationCore.Specifications
{
    public class SoftwareLicenseTypeWithSpecification : BaseSpecification<SoftwareLicenseType>
    {
        public SoftwareLicenseTypeWithSpecification(string id) : base(i => i.Id == id)
        {

        }

        public SoftwareLicenseTypeWithSpecification(int skip, int take, SoftwareLicenseType licenseType, string OrderBy = null, bool isDescending = false)
            : base(i => (string.IsNullOrEmpty(licenseType.Name) || i.Name.StartsWith(licenseType.Name)))
        {
            ApplyPaging(skip, take);

            if (!string.IsNullOrEmpty(OrderBy))
            {
                ApplyOrderBy(OrderBy, isDescending);
            }
        }
    }
}

