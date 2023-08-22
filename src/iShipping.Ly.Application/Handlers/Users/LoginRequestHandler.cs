using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, (Result, object)>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(Result, object)> Handle(LoginRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.Users.AuthenticateAsync(request);
    }
}
