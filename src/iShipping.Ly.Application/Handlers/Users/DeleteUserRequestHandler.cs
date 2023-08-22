using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.Users.RemoveUserAsync(request.UserId);
    }
}
