using IToNeo.ApplicationCore.Entities;
using IToNeo.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IToNeo.Infrastructure.Data
{
    public class EfReadOnlyRepository<T> : IReadOnlyAsyncRepository<T> where T : BaseEntity
    {
        protected readonly IToNeoContext _dbIToNeoContext;
        
        public EfReadOnlyRepository(IToNeoContext dbIToNeoContext)
        {
            _dbIToNeoContext = dbIToNeoContext;
            SetContextQueryTrackingBehavior(_dbIToNeoContext, QueryTrackingBehavior.NoTracking);
        }
        
        protected static void SetContextQueryTrackingBehavior(DbContext context, QueryTrackingBehavior queryTrackingBehavior)
        {
            context.ChangeTracker.QueryTrackingBehavior = queryTrackingBehavior;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _dbIToNeoContext.Set<T>().FindAsync(id);
        }
       
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbIToNeoContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbIToNeoContext.Set<T>().AsQueryable(), spec);
        }
    }
}
