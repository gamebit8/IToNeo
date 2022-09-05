using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
using IToNeo.WebAPI.Services.SystemTextJson;
using System;
using System.Text.Json.Serialization;

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenses
{
    public class CreateSoftwareLicenseResult : CreateBaseResult
    {
        public int Count { get; set; }
        public string LicenseCode { get; set; }
        public string Note { get; set; }
        public string TypeId { get; set; }
        public string SoftwareId { get; set; }
        public string OrganizationId { get; set; }
        public string FileId { get; set; }
    }
}
