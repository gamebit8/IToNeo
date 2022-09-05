using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.ApplicationCore.Helpers.Query;
using Microsoft.EntityFrameworkCore;

namespace IToNeo.ApplicationCore.Specifications
{
    public class SoftwareWithSpecification : BaseSpecification<Software>
    {
        public SoftwareWithSpecification(string id) : base(i => i.Id == id)
        {
            ApplyInclude();
        }

        public SoftwareWithSpecification(int skip, int take, Software software, string OrderBy = null, bool isDescending = false)
            : base(i => (string.IsNullOrEmpty(software.Name) || i.Name.StartsWith(software.Name)) &&
             (string.IsNullOrEmpty(software.DeveloperId) || i.DeveloperId == software.DeveloperId) &&
             (string.IsNullOrEmpty(software.Note) || i.Note.StartsWith(software.Note))
            )
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
            AddIncludes(query => query
                .Include(s => s.Developer)
                .Include(s => s.Licenses).ThenInclude(sl => sl.Type)
                //.Include(s => s.Licenses).ThenInclude(sl => sl.Equipments)
            );
        }
        
    }
}

