using IToNeo.ApplicationCore.Entities.EquipmentAggregate;

namespace IToNeo.ApplicationCore.Specifications
{
    public class EquipmentStatusWithSpecification : BaseSpecification<EquipmentStatus>
    {
        public EquipmentStatusWithSpecification(string id) : base(i => i.Id == id)
        {
        }

        public EquipmentStatusWithSpecification(int skip, int take, EquipmentStatus equipmentStatus, string orderBy = null, bool isDescending = false)
            : base(i => (string.IsNullOrEmpty(equipmentStatus.Name) || i.Name.StartsWith(equipmentStatus.Name)))
        {
            ApplyPaging(skip, take);

            if (!string.IsNullOrEmpty(orderBy))
                ApplyOrderBy(orderBy, isDescending);
        }
    }
}

