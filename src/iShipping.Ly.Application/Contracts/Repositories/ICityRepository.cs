using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.City;
using iShipping.Ly.Domain.Entities;

namespace iShipping.Ly.Application.Contracts.Repositories
{
    public interface ICityRepository : IAsyncRepository<City>
    {
        public Task<Response<GetCitiesResponse>> GetResponseAsync(GetCitiesRequest request, CancellationToken cancellationToken = default);
    }
}
