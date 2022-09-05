using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetById;

namespace IToNeo.WebAPI.ApiEndpoints.V1.EquipmentsSoftwareLicenses
{
    public class GetByIdEquipmentSoftwareLicenseResult : GetByIdBaseResult
    {
        public string EquipmentId { get; set; }
        public string SoftwareLicenceId { get; set; }
    }
}
