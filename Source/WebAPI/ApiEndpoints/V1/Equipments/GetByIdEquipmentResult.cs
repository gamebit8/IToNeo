using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetById;
using IToNeo.WebAPI.ApiEndpoints.V1.Equipments.Disposals;
using IToNeo.WebAPI.ApiEndpoints.V1.Equipments.WriteOffs;
using IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenses;
using IToNeo.WebAPI.Services.SystemTextJson;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IToNeo.WebAPI.ApiEndpoints.V1.Equipments
{
    public class GetByIdEquipmentResult : GetByIdBaseResult
    {
        public EntityBaseResult Status { get; set; }
        public EntityBaseResult Organization { get; set; }
        public EntityBaseResult Type { get; set; }
        public EntityBaseResult Employee { get; set; }
        public GetByIdEquipmentWriteOffResult WriteOff { get; set; }
        public GetByIdEquipmentDisposalResult Disposal { get; set; }
        public IEnumerable<GetSoftwareLicensesResult> SoftwareLicenses { get; set; }
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
