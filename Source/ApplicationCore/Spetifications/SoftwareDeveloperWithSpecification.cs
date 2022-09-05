using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.ApplicationCore.Helpers.Query;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IToNeo.ApplicationCore.Specifications
{
    public class SoftwareDeveloperWithSpecification : BaseSpecification<SoftwareDeveloper>
    {
        public SoftwareDeveloperWithSpecification(string id) : base(i => i.Id == id)
        {

        }

        public SoftwareDeveloperWithSpecification(int skip, int take, SoftwareDeveloper developer, string OrderBy = null, bool isDescending = false)
            : base(i => (string.IsNullOrEmpty(developer.Name) || i.Name.StartsWith(developer.Name)))
            
        {
            ApplyPaging(skip, take);

            if (!string.IsNullOrEmpty(OrderBy))
            {
                ApplyOrderBy(OrderBy, isDescending);
            }
        }
        
    }
}

