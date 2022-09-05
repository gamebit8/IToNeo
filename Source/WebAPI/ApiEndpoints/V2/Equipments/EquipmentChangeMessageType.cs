using GraphQL.Types;
using IToNeo.WebAPI.ApiEndpoints.V2.Equipments;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class EquipmentChangeMessageType : ObjectGraphType<EquipmentChangeMessage>
    {
        public EquipmentChangeMessageType()
        {
            Field(m => m.EquipmentId);
            Field(m => m.User);
            Field(m => m.UserId);
            Field(m => m.ChangedEquipment, type: typeof(EquipmentGraphType)).Resolve(m => m.Source.ChangedEquipment);
        }
    }
}
