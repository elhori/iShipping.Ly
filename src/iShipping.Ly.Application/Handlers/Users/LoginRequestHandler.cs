using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, (Result, object)>
    {
        private readonly IUserService _userService;

        public LoginRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<(Result, object)> Handle(LoginRequest request, CancellationToken cancellationToken)
            => await _userService.AuthenticateAsync(request, cancellationToken);
    }
}
