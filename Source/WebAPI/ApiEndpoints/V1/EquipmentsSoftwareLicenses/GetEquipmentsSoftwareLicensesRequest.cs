using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.EquipmentsSoftwareLicenses
{
    public class GetEquipmentsSoftwareLicensesRequest : GetListBaseRequest
    {
        public string EquipmentId { get; set; }
        public string SoftwareLicenceId { get; set; }
    }
}
