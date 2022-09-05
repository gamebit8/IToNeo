using GraphQL.Types;
using IToNeo.ApplicationCore.Entities.EquipmentAggregate;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class EquipmentStatusGraphType : ObjectGraphType<EquipmentStatus>
    {
        public EquipmentStatusGraphType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}
