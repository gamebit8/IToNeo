using GraphQL.Types;
using IToNeo.ApplicationCore.Entities;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class EmployeeGraphType : ObjectGraphType<Employee>
    {
        public EmployeeGraphType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}
