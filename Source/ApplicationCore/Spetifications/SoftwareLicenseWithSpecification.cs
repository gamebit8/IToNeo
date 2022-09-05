using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.ApplicationCore.Helpers.Query;
using Microsoft.EntityFrameworkCore;

namespace IToNeo.ApplicationCore.Specifications
{
    public class SoftwareLicenseWithSpecification : BaseSpecification<SoftwareLicense>
    {
        public SoftwareLicenseWithSpecification(string id) : base(i => i.Id == id)
        {
            ApplyInclude();

            AddIncludes(query => query.Include(sl => sl.Equipments).ThenInclude(e => e.Type));
            AddIncludes(query => query.Include(sl => sl.Equipments).ThenInclude(e => e.Organization));
            AddIncludes(query => query.Include(sl => sl.Equipments).ThenInclude(e => e.Employee));
            AddIncludes(query => query.Include(sl => sl.Equipments).ThenInclude(e => e.Place));
        }

        public SoftwareLicenseWithSpecification(int skip, int take, SoftwareLicense license, string OrderBy = null, bool isDescending = false)
            : base(i => (string.IsNullOrEmpty(license.Name) || i.Name.StartsWith(license.Name)) &&
                (string.IsNullOrEmpty(license.TypeId) || i.TypeId == license.TypeId) &&
                (string.IsNullOrEmpty(license.SoftwareId) || i.SoftwareId == license.SoftwareId) &&
                (string.IsNullOrEmpty(license.OrganizationId) || i.OrganizationId == license.OrganizationId) &&
                (license.Count == 0 || i.Count == license.Count) &&
                (string.IsNullOrEmpty(license.Note) || i.Note.StartsWith(license.Note)) &&
                (string.IsNullOrEmpty(license.LicenseCode) || i.LicenseCode.StartsWith(license.LicenseCode)))

        {
            ApplyInclude();

            ApplyPaging(skip, take);

            if (!string.IsNullOrEmpty(OrderBy))
            {
                ApplyOrderBy(OrderBy, isDescending);
            }
        }

        private void ApplyInclude()
        {
            AddIncludes(query => query.Include(sl => sl.Type));
            AddIncludes(query => query.Include(sl => sl.Software).ThenInclude(s => s.Developer));
            AddIncludes(query => query.Include(sl => sl.Organization));
            AddIncludes(query => query.Include(sl => sl.Equipments));
            AddIncludes(query => query.Include(sl => sl.File));
        }
        
    }
}

