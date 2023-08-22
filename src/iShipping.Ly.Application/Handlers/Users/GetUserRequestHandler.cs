using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, GetUsersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetUsersResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.Users.GetUserAsync(request.userId, cancellationToken);
    }
}
