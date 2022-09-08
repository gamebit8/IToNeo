using IToNeo.Infrastructure.Identity.Entities;
using IToNeo.WebAPI.ApiEndpoints.V1.Users;
using System.Linq;

namespace IToNeo.ApplicationCore.Specifications
{
    public class UserWithSpecification : BaseSpecification<ApplicationUser>
    {
        public UserWithSpecification(int skip, int take, GetUsersRequest request, string OrderBy = null, bool isDescending = false)
            : base(u => (u.UserName.StartsWith(request.UserName) || string.IsNullOrEmpty(request.UserName)) &&
            (u.Email.StartsWith(request.Email) || string.IsNullOrEmpty(request.Email)) &&
            (u.PhoneNumber.StartsWith(request.PhoneNumber) || string.IsNullOrEmpty(request.PhoneNumber)) &&
            (u.EmployeeId == request.EmployeeId || string.IsNullOrEmpty(request.EmployeeId)) &&
            (u.Roles.Where(r => r.Id == request.RoleId).Any() || string.IsNullOrEmpty(request.RoleId)))
        {
            ApplyPaging(skip, take);

            AddIncludes(query => query.Include(u => u.Roles));

            if (!string.IsNullOrEmpty(OrderBy))
            {
                ApplyOrderBy(OrderBy, isDescending);
            }
        }
    }
}
