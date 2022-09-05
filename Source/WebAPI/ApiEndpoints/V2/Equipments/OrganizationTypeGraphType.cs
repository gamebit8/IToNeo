using GraphQL.Types;
using IToNeo.ApplicationCore.Entities;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class OrganizationGraphType : ObjectGraphType<Organization>
    {
        public OrganizationGraphType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}
