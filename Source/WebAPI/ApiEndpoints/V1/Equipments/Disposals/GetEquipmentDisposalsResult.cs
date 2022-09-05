using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;
using System.Text.Json.Serialization;
using IToNeo.WebAPI.Services.SystemTextJson;
using System;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Disposals
{
    public class GetEquipmentDisposalsResult : GetListBaseResult
    {
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime Date { get; set; }
        public float ResalePrice { get; set; }
        public string Note { get; set; }
        public string EquipmentId { get; set; }
    }
}
