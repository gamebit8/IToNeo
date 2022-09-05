using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetById;
using System.Collections.Generic;

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenses
{
    public class GetByIdSoftwareLicenseResult : GetByIdBaseResult
    {
        public int Count { get; set; }
        public string LicenseCode { get; set; }
        public string Note { get; set; }
        public EntityBaseResult Type { get; set; }
        public EntityBaseResult Software { get; set; }
        public EntityBaseResult Developer { get; set; }
        public EntityBaseResult Organization { get; set; }
        public EntityBaseResult File { get; set; }
        public int UsedLicenses { get; set; }
        public IEnumerable<GetByIdSoftwareLicenseEquipmentResult> Equipments { get; set; }
    }
}
