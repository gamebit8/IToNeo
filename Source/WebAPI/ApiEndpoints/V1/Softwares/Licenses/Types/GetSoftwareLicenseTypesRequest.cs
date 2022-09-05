using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenseTypes
{
    public class GetSoftwareLicenseTypesRequest : GetListBaseRequest
    {
        public string Name { get; set; }
    }
}
