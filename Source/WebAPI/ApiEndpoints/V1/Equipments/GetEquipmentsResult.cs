using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;
using System.Text.Json.Serialization;
using IToNeo.WebAPI.Services.SystemTextJson;
using System;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments
{
    public class GetEquipmentsResult : GetListBaseResult
    {
        public EntityBaseResult Status { get; set; }
        public EntityBaseResult Organization { get; set; }
        public EntityBaseResult Type { get; set; }
        public EntityBaseResult Employee { get; set; }
        public EntityBaseResult WriteOff { get; set; }
        public EntityBaseResult Disposal { get; set; }
        public string InventoryNumber { get; set; }
        public EntityBaseResult Place { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? DateOfCreation { get; set; }
        public EntityBaseResult File { get; set; }
        public string SerialNumber { get; set; }
        public string Note { get; set; }
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? DateOfInstallation { get; set; }
    }
}
