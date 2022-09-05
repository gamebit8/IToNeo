using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Employees
{
    public class GetEmployeesResult : GetListBaseResult
    {
        public string Department { get; set; }
        public string Position { get; set; }
        public EntityBaseResult Organization { get; set; }
    }
}
