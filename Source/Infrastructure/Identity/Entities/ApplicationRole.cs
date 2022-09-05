using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IToNeo.Infrastructure.Identity.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {

        }
        public ApplicationRole(string roleName)
            : base(roleName)
        {

        }
        public virtual List<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; } = new HashSet<ApplicationUser>();
    }
}
