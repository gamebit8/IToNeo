using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Employees
{
    public class CreateEmployeeResult : CreateBaseResult
    {
        public string Username { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public string OrganizationId { get; set; }
    }
}
