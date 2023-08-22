using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RegisterRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.Users.RegisterAsync(request);
    }

    public class CreateAdminRequestHandler : IRequestHandler<CreateAdminRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAdminRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateAdminRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.Users.CreateAdminAsync(request);
    }
}
