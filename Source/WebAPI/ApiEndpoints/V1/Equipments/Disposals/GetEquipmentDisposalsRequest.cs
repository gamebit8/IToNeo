using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Disposals
{
    public class GetEquipmentDisposalsRequest : GetListBaseRequest
    {
        public float ResalePrice { get; set; }
        public string Note { get; set; }
        public string EquipmentId { get; set; }
    }
}
