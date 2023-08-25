using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.States;
using iShipping.Ly.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace iShipping.Ly.Infra.Persistence.Repositories
{
    public class StateRepository : AsyncRepository<State>, IStateRepository
    {
        private readonly DataContext _context;

        public StateRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Response<GetStatesResponse>> GetResponseAsync(GetStatesRequest request, CancellationToken cancellationToken = default)
        {
            var data = _context.States.AsNoTracking();

            var skip = request.PageSize * (request.CurrentPage - 1);

            var totalResults = await data.CountAsync(cancellationToken);

            var results = await data
                .OrderBy(i => i.Id)
                .Skip(skip)
                .Take(request.PageSize)
                .Select(i => new GetStatesResponse
                {
                    Id = i.Id,
                    Name = i.Name,
                    CityId = i.CityId,
                    CityName = i.City.Name

                }).ToListAsync(cancellationToken);

            return new Response<GetStatesResponse>
            {
                CurrentPage = request.CurrentPage,
                PageSize = request.PageSize,
                TotalResults = totalResults,
                Results = results
            };
        }
    }
}
