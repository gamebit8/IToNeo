using IToNeo.WebAPI.ApiEndpoints.V1.Base.Update;
using IToNeo.WebAPI.Services.SystemTextJson;
using System;
using System.Text.Json.Serialization;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments.WriteOffs
{
    public class UpdateEquipmentWriteOffRequestBody : UpdateBaseRequestBody
    {
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime Date { get; set; }
        public float LiquidationValue { get; set; }
        public string Note { get; set; }
        public string EquipmentId { get; set; }
    }
}
