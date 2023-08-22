using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class UpdateUserProfileRequestHandler : IRequestHandler<UpdateUserProfileRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserProfileRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateUserProfileRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.Users.UpdateUserProfileAsync(request);
    }
}
