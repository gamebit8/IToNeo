using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IToNeo.Infrastructure.Data
{
    public class EfRepository<T> : EfReadOnlyRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        public EfRepository(IToNeoContext dbIToNeoContext)
            : base(dbIToNeoContext)
        {
            SetContextQueryTrackingBehavior(_dbIToNeoContext, QueryTrackingBehavior.TrackAll);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbIToNeoContext.Set<T>().AddAsync(entity);
            await _dbIToNeoContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync (T entity)
        {
            _dbIToNeoContext.Entry(entity).State = EntityState.Modified;
            await _dbIToNeoContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbIToNeoContext.Set<T>().Remove(entity);
            await _dbIToNeoContext.SaveChangesAsync();
        }
    }
}
