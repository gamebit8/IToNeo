using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Employees
{
    public class GetEmployeesShortRequest : GetListBaseRequest
    {
        public string Name { get; set; }
    }
}
