using System.Linq.Expressions;

namespace iShipping.Ly.Application.Contracts.Repositories
{
    public interface IAsyncRepository<TDomain> where TDomain : class
    {
        Task AddAsync(TDomain entity, CancellationToken cancellationToken = default);
        Task AddRangeAync(IEnumerable<TDomain> entities, CancellationToken cancellationToken = default);
        Task RemoveAsync(TDomain entitiy, CancellationToken cancellationToken = default);
        Task RemoveRangeAsync(IList<TDomain> entities, CancellationToken cancellationToken = default);
        Task<TDomain> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TDomain>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TDomain, TResult>> target, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<TDomain, bool>> target, CancellationToken cancellationToken = default);
    }
}
