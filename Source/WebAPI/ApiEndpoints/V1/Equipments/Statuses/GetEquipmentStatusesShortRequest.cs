using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Statuses
{
    public class GetEquipmentStatusesShortRequest : GetListBaseRequest
    {
        public string Name { get; set; }
    }
}
