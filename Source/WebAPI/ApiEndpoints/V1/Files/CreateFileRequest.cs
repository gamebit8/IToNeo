using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
using IToNeo.WebAPI.Services.SystemTextJson;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json.Serialization;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Files
{
    public class CreateFileRequest : CreateBaseRequest
    {
        public string EquipmentId { get; set; }
        public string SoftwareLicenseId { get; set; }
        public string EmployeeId { get; set; }
        public IFormFile Content { get; set; }
    }
}
