using iShipping.Ly.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iShipping.Ly.Infra.Persistence.Repositories
{
    public class AsyncRepository<TDomain> : IAsyncRepository<TDomain> where TDomain : class
    {
        private readonly DataContext _context;
        public AsyncRepository(DataContext appDbContext)
        {
            _context = appDbContext;
        }
        public virtual async Task AddAsync(TDomain entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<TDomain>().AddAsync(entity, cancellationToken);
        }

        public virtual async Task AddRangeAync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default)
        {
            await _context.Set<TDomain>().AddRangeAsync(entities, cancellationToken);
        }
        public virtual async Task<TDomain> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TDomain>().FindAsync(id) ?? default!;
        }

        public virtual async Task<IEnumerable<TDomain>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<TDomain>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<TResult>> GetAllAsync<TResult>(
            Expression<Func<TDomain, TResult>> target, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TDomain>().AsNoTracking()
                                    .Select(target)
                                    .ToListAsync(cancellationToken);
        }

        public virtual async Task RemoveAsync(TDomain entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _context.Set<TDomain>().Remove(entity), cancellationToken);
        }

        public async Task RemoveRangeAsync(IList<TDomain> entities, CancellationToken cancellationToken = default)
        {
            await Task.Run(() => _context.Set<TDomain>().RemoveRange(entities), cancellationToken);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TDomain, bool>> target, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TDomain>().AnyAsync(target, cancellationToken);
        }
    }

}
