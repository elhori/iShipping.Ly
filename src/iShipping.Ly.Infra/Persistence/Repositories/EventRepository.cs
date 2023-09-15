using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace iShipping.Ly.Infra.Persistence.Repositories
{
    public class EventRepository : AsyncRepository<Event>, IEventRepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllByAggregateIdAsync(int aggregateId, CancellationToken cancellationToken)
            => await _context.Events
                .AsNoTracking()
                .Where(e => e.AggregateId == aggregateId)
                .OrderBy(e => e.Sequence)
                .ToListAsync(cancellationToken);

        public async Task<IEnumerable<Event>> GetAsPaginationAsync(int currentPage = 1, int pageSize = 25)
        {
            var skip = (currentPage - 1) * pageSize;

            return await _context.Events
                .AsNoTracking()
                .OrderBy(e => e.AggregateId)
                .ThenBy(e => e.Sequence)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
