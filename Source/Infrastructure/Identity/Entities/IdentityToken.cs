using System;
using System.Collections.Generic;
using System.Text;

namespace IToNeo.Infrastructure.Identity.Entities
{
    public class IdentityToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
