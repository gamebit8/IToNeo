using IToNeo.ApplicationCore.Entities.EquipmentAggregate;

namespace IToNeo.ApplicationCore.Specifications
{
    public class EquipmentTypeWithSpecification : BaseSpecification<EquipmentType>
    {
        public EquipmentTypeWithSpecification(string id) : base(i => i.Id == id)
        {
        }

        public EquipmentTypeWithSpecification(int skip, int take, EquipmentType equipmentType, string orderBy = null, bool isDescending = false)
            :base(i => (string.IsNullOrEmpty(equipmentType.Name) || i.Name.StartsWith(equipmentType.Name)))
        {
            ApplyPaging(skip, take);

            if (!string.IsNullOrEmpty(orderBy))
                ApplyOrderBy(orderBy, isDescending);
        }
    }
}

