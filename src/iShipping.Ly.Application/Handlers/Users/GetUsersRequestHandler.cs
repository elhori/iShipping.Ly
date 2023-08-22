using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, Response<GetUsersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUsersRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<GetUsersResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.Users.GetUsersAsync(request);
    }
}
