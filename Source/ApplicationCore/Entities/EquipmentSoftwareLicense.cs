using IToNeo.ApplicationCore.Entities.EquipmentAggregate;
using IToNeo.ApplicationCore.Entities.SoftwareAggregate;
using IToNeo.ApplicationCore.Interfaces;

namespace IToNeo.ApplicationCore.Entities
{
    public class EquipmentSoftwareLicense : BaseEntity, IUpdateEntity<EquipmentSoftwareLicense>
    {
        public string EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
        public string SoftwareLicenceId { get; set; }
        public SoftwareLicense SoftwareLicence { get; set; }

        public EquipmentSoftwareLicense() { }

        public EquipmentSoftwareLicense(string equipmentId, string softwareLicenceId)
        {
            EquipmentId = equipmentId;
            SoftwareLicenceId = softwareLicenceId;
        }

        public void Update(EquipmentSoftwareLicense entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
