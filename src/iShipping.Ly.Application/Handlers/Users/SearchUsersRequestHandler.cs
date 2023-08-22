using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class SearchUsersRequestHandler : IRequestHandler<SearchUsersRequest, Response<GetUsersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchUsersRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<GetUsersResponse>> Handle(SearchUsersRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.Users.SearchAsync(request);
    }
}
