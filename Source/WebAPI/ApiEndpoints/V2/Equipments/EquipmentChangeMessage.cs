using IToNeo.ApplicationCore.Entities.EquipmentAggregate;

namespace IToNeo.WebAPI.ApiEndpoints.V2.Equipments
{
    public class EquipmentChangeMessage
    {
        public string EquipmentId { get; set; }
        public string UserId { get; set; }
        public string User { get; set; }
        public Equipment ChangedEquipment { get; set; }
    }
}
