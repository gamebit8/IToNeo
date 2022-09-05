using IToNeo.WebAPI.ApiEndpoints.V1.Base.Delete;
using Microsoft.AspNetCore.Mvc;

namespace IToNeo.WebAPI.ApiEndpoints.V1.EquipmentsSoftwareLicenses
{
    public class DeleteEquipmentSoftwareLicenseRequest : DeleteBaseRequest
    {
        public string EquipmentId { get; set; }
        public string SoftwareLicenseId { get; set; }
    }
}
