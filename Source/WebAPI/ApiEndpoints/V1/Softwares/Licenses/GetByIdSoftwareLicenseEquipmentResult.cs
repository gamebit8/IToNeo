using IToNeo.WebAPI.ApiEndpoints.V1.Base;
using IToNeo.WebAPI.ApiEndpoints.V1.Base.GetList;

namespace IToNeo.WebAPI.ApiEndpoints.V1.SoftwareLicenses
{
    public class GetByIdSoftwareLicenseEquipmentResult : GetListBaseResult
    {
        public EntityBaseResult Type { get; set; }
        public string InventoryNumber { get; set; }
        public string SerialNumber { get; set; }
        public EntityBaseResult Organization { get; set; }
        public EntityBaseResult Employee { get; set; }
        public EntityBaseResult Place { get; set; }
      
    }
}
