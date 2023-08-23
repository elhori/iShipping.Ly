using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Address;
using iShipping.Ly.Domain.Entities;

namespace iShipping.Ly.Application.Contracts.Repositories
{
    public interface IAddressRepository : IAsyncRepository<Address>
    {
        public Task<Response<GetAddressesResponse>> GetResponseAsync(GetAddressesRequest request, CancellationToken cancellationToken = default);
    }
}
