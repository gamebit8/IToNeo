using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetById;
using Microsoft.AspNetCore.Http;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Files
{
    public class GetByIdFileResult : GetByIdBaseResult
    {
        public string EquipmentId { get; set; }
        public string SoftwareLicenseId { get; set; }
        public string EmployeeId { get; set; }
        public IFormFile Content { get; set; }
    }
}
