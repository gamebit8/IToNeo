using IToNeo.WebAPI.ApiEndpoints.V1.Base.Create;
using IToNeo.WebAPI.Services.SystemTextJson;
using System;
using System.Text.Json.Serialization;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments
{
    public class CreateEquipmentResult : CreateBaseResult
    {
        public string SerialNumber { get; set; }
        public string Note { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? DateOfInstallation { get; set; }
        public string StatusId { get; set; }
        public string OrganizationId { get; set; }
        public string TypeId { get; set; }
        public string EmployeeId { get; set; }
        public string PlaceId { get; set; }
        public string DisposalId { get; set; }
        public string WriteOffId { get; set; }
        public string InventoryNumber { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? DateOfCreation { get; set; }
    }
}
