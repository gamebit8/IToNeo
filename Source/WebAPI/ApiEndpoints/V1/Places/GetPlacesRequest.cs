using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Places
{
    public class GetPlacesRequest : GetListBaseRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
