using IToNeo.ApplicationCore.Entities;

namespace IToNeo.ApplicationCore.Specifications
{
    public class FileEntityWithSpecification : BaseSpecification<FileEntity>
    {
        public FileEntityWithSpecification(string id) : base(i => i.Id == id)
        {
        }
        public FileEntityWithSpecification(int skip, int take, string OrderBy = null, bool isDescending = false)
        {
            ApplyPaging(skip, take);

            if (!string.IsNullOrEmpty(OrderBy))
            {
                ApplyOrderBy(OrderBy, isDescending);
            }
        }
    }
}

