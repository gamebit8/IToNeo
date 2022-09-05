using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenses
{
    public class GetSoftwareLicensesRequest : GetListBaseRequest
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public string CodeLisense { get; set; }
        public string Note { get; set; }
        public string TypeId { get; set; }
        public string SoftwareId { get; set; }
        public string OrganizationId { get; set; }
    }
}
