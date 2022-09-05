using IToNeo.ApplicationCore.Entities;


namespace IToNeo.ApplicationCore.Specifications
{
    public class WriteOffWithSpecification : BaseSpecification<EquipmentWriteOff>
    {
        public WriteOffWithSpecification(string id) : base(i => i.Id == id)
        {
        }

        public WriteOffWithSpecification(EquipmentWriteOff writeOff)
         : base(i => (string.IsNullOrEmpty(writeOff.Note) || i.Note.StartsWith(writeOff.Note)) &&
            (writeOff.LiquidationValue == 0 || i.LiquidationValue == writeOff.LiquidationValue) &&
            (string.IsNullOrEmpty(writeOff.EquipmentId) || i.EquipmentId == writeOff.EquipmentId))
        {
        }

        public WriteOffWithSpecification(int skip, int take, EquipmentWriteOff writeOff, string OrderBy = null, bool isDescending = false)
            :this(writeOff)
        {
            ApplyPaging(skip, take);
        }

    }
}
