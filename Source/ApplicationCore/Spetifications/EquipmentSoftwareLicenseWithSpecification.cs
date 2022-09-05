using IToNeo.ApplicationCore.Entities;

namespace IToNeo.ApplicationCore.Specifications
{
    public class EquipmentSoftwareLicenseWithSpecification : BaseSpecification<EquipmentSoftwareLicense>
    {

        public EquipmentSoftwareLicenseWithSpecification(EquipmentSoftwareLicense esl, int take = 1, int skip = 0)
            : base(i => (((string.IsNullOrEmpty(esl.EquipmentId)) || (esl.EquipmentId == i.EquipmentId)) &&
                  ((string.IsNullOrEmpty(esl.SoftwareLicenceId) || (esl.SoftwareLicenceId == i.SoftwareLicenceId)))))
            
        {
            ApplyPaging(skip, take);
        }
        
    }
}

