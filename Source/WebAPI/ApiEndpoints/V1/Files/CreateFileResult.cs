using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
using Microsoft.AspNetCore.Http;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Files
{
    public class CreateFileResult : CreateBaseResult
    {
        public string EquipmentId { get; set; }
        public string SoftwareLicenseId { get; set; }
        public string EmployeeId { get; set; }
        public IFormFile Content { get; set; }
    }
}
