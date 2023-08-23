using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.States;
using iShipping.Ly.Domain.Entities;

namespace iShipping.Ly.Application.Contracts.Repositories
{
    public interface IStateRepository : IAsyncRepository<State>
    {
        public Task<Response<GetStatesResponse>> GetResponseAsync(GetStatesRequest request, CancellationToken cancellationToken = default);
    }
}
