using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;
using IToNeo.WebAPI.Services.SystemTextJson;
using System;
using System.Text.Json.Serialization;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments
{
    public class GetEquipmentsRequest : GetListBaseRequest
    {
        public string Name { get; set; }
        public string InventoryNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Note { get; set; }
        public string StatusId { get; set; }
        public string OrganizationId { get; set; }
        public string PlaceId { get; set; }
        public string TypeId { get; set; }
        public string EmployeeId { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? DateOfInstallationTo { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? DateOfInstallationFrom { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? DateOfCreationTo { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? DateOfCreationFrom { get; set; }
    }
}
