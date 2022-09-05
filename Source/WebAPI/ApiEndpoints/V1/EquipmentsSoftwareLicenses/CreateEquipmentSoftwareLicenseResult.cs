using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
using IToNeo.WebAPI.Services.SystemTextJson;
using System;
using System.Text.Json.Serialization;

namespace IToNeo.WebAPI.ApiEndpoints.V1.EquipmentsSoftwareLicenses
{
    public class CreateEquipmentSoftwareLicenseResult : CreateBaseResult
    {
        public string EquipmentId { get; set; }
        public string SoftwareLicenceId { get; set; }
    }
}
