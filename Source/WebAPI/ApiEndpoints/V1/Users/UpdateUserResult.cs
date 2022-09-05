using IToNeo.WebAPI.ApiEndpoints.V1.Base.Update;
using System.Collections.Generic;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Users
{
    public class UpdateUserResult : UpdateBaseResult
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmployeeId { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
