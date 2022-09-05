using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Helpers.Query;


namespace IToNeo.ApplicationCore.Specifications
{
    public class OrganizationWithSpecification : BaseSpecification<Organization>
    {
        public OrganizationWithSpecification(string id) : base(i => i.Id == id)
        {
        }
        public OrganizationWithSpecification(int skip, int take, Organization organization, string OrderBy = null, bool isDescending = false)
            : base(i => (string.IsNullOrEmpty(organization.Name) || i.Name.StartsWith(organization.Name)))
        {
            ApplyPaging(skip, take);

            if (!string.IsNullOrEmpty(OrderBy))
            {
                ApplyOrderBy(OrderBy, isDescending);
            }
        }
    }
}

