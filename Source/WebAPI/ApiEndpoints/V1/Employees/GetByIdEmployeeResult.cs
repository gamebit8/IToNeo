using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetById;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Employees
{
    public class GetByIdEmployeeResult : GetByIdBaseResult
    {
        public string Username { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public EntityBaseResult Organization { get; set; }
        public EntityBaseResult File { get; set; }
    }
}
