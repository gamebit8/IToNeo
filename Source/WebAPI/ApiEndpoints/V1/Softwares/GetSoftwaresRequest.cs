using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Softwares
{
    public class GetSoftwaresRequest : GetListBaseRequest
    {
        public string Name { get; set; }
    }
}
