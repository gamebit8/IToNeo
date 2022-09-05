using GraphQL.Types;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class EquipmentTypeGraphType : ObjectGraphType<EquipmentType>
    {
        public EquipmentTypeGraphType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}
