using iShipping.Ly.Domain.Entities;

namespace iShipping.Ly.Application.Contracts.Repositories
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<IEnumerable<Event>> GetAllByAggregateIdAsync(int aggregateId, CancellationToken cancellationToken);
        Task<IEnumerable<Event>> GetAsPaginationAsync(int currentPage = 1, int pageSize = 25);
    }
}
