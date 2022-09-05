using IToNeo.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IToNeo.ApplicationCore.Interfaces
{
    public interface IReadOnlyAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}
