using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Employees
{
    public class GetEmployeesRequest : GetListBaseRequest
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string OrganizationId { get; set; }
    }
}
