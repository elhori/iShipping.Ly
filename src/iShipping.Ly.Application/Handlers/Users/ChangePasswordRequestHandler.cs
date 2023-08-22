using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class ChangePasswordRequestHandler : IRequestHandler<ChangePasswordRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangePasswordRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.Users.ChangePasswordAsync(request);
    }
}
