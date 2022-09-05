using Microsoft.AspNetCore.Identity;
using System;

namespace IToNeo.Infrastructure.Identity.Entities
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual ApplicationRole Role { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
