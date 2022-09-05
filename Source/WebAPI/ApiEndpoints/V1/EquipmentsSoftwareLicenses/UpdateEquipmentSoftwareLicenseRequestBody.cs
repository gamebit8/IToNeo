using IToNeo.WebAPI.ApiEndpoints.V1.Base.Update;

namespace IToNeo.WebAPI.ApiEndpoints.V1.EquipmentsSoftwareLicenses
{
    public class UpdateEquipmentSoftwareLicenseRequestBody : UpdateBaseRequestBody
    {
        public string EquipmentId { get; set; }
        public string SoftwareLicenceId { get; set; }
    }
}
