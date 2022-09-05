using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Developers
{
    public class GetDevelopersRequest : GetListBaseRequest
    {
        public string Name { get; set; }
    }
}
