using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments
{
    public class GetEquipmentsShortRequest : GetListBaseRequest
    {
        public string Name { get; set; }
    }
}
