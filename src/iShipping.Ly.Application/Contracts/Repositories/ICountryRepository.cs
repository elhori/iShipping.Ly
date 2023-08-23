using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Country;
using iShipping.Ly.Domain.Entities;

namespace iShipping.Ly.Application.Contracts.Repositories
{
    public interface ICountryRepository : IAsyncRepository<Country>
    {
        public Task<Response<GetCountriesResponse>> GetResponseAsync(GetCountriesRequest request, CancellationToken cancellationToken = default);
    }
}
