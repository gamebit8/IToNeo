using IToNeo.ApplicationCore.Entities;

namespace IToNeo.ApplicationCore.Specifications
{
    public class DisposalWithSpecification : BaseSpecification<EquipmentDisposal>
    {
        public DisposalWithSpecification(string id) : base(i => i.Id == id)
        {
        }
        public DisposalWithSpecification(int skip, int take, EquipmentDisposal disposal, string orderBy = null, bool isDescending = false)
            : base(i => (string.IsNullOrEmpty(disposal.Note) || i.Note.StartsWith(disposal.Note)) &&
            (disposal.ResalePrice == 0 || i.ResalePrice == disposal.ResalePrice) &&
            (string.IsNullOrEmpty(disposal.EquipmentId) || i.EquipmentId == disposal.EquipmentId))
        {
            ApplyPaging(skip, take);

            if(string.IsNullOrEmpty(orderBy))
                ApplyOrderBy(orderBy, isDescending);
        }

    }
}