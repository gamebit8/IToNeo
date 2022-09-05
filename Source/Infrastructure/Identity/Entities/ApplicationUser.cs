using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IToNeo.Infrastructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }
        public ApplicationUser(string userName)
            : base(userName)
        {

        }
        public string EmployeeId { get; set; }
        public virtual List<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRole> Roles { get; set; } = new HashSet<ApplicationRole>();
    }
}
