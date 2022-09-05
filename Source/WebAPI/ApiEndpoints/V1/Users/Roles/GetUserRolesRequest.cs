using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.UserRoles
{
    public class GetUserRolesRequest : GetListBaseRequest
    {
        public string Name { get; set; }
    }
}
