using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.City;
using iShipping.Ly.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace iShipping.Ly.Infra.Persistence.Repositories
{
    public class CityRepository : AsyncRepository<City>, ICityRepository
    {
        private readonly DataContext _context;

        public CityRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Response<GetCitiesResponse>> GetResponseAsync(GetCitiesRequest request, CancellationToken cancellationToken = default)
        {
            var data = _context.Cities.AsNoTracking();

            var skip = request.PageSize * (request.CurrentPage - 1);

            var totalResults = await data.CountAsync();

            var results = await data
                .OrderBy(i => i.Id)
                .Skip(skip)
                .Take(request.PageSize)
                .Select(i => new GetCitiesResponse
                {
                    Id = i.Id,
                    Name = i.Name,
                    AddressId = i.AddressId,
                    Address = $"{i.Address.City.Name} - {i.Address.City.StateId}",
                    StateId = i.StateId,
                    StateName = i.State.Name

                }).ToListAsync(cancellationToken);

            return new Response<GetCitiesResponse>
            {
                CurrentPage = request.CurrentPage,
                PageSize = request.PageSize,
                TotalResults = totalResults,
                Results = results
            };
        }
    }
}
