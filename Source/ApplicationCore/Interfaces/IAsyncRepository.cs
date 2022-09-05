using IToNeo.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace IToNeo.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> : IReadOnlyAsyncRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
