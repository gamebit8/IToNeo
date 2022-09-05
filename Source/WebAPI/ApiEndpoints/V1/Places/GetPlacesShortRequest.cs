using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Places
{
    public class GetPlacesShortRequest : GetListBaseRequest
    {
        public string Name { get; set; }
    }
}
