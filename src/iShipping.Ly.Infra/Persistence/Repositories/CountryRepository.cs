using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Country;
using iShipping.Ly.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace iShipping.Ly.Infra.Persistence.Repositories
{
    public class CountryRepository : AsyncRepository<Country>, ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Response<GetCountriesResponse>> GetResponseAsync(GetCountriesRequest request, CancellationToken cancellationToken = default)
        {
            var data = _context.Countries.AsNoTracking();

            var skip = request.PageSize * (request.CurrentPage - 1);

            var totalResults = await data.CountAsync(cancellationToken);

            var results = await data
                .OrderBy(i => i.Id)
                .Skip(skip)
                .Take(request.PageSize)
                .Select(i => new GetCountriesResponse
                {
                    Id = i.Id,
                    Name = i.Name

                }).ToListAsync(cancellationToken);

            return new Response<GetCountriesResponse>
            {
                CurrentPage = request.CurrentPage,
                PageSize = request.PageSize,
                TotalResults = totalResults,
                Results = results
            };
        }
    }
}
