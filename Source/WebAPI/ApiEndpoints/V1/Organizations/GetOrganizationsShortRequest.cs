using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Organizations
{
    public class GetOrganizationsShortRequest : GetListBaseRequest
    {
        public string Name { get; set; }
    }
}
