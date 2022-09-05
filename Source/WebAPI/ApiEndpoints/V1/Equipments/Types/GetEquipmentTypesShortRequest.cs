using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Types
{
    public class GetEquipmentTypesShortRequest : GetListBaseRequest
    {
        public string Name { get; set; }
    }
}
