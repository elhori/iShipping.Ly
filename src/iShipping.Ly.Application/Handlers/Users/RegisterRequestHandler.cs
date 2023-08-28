using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, Result>
    {
        private readonly IUserService _userService;

        public RegisterRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(RegisterRequest request, CancellationToken cancellationToken)
            => await _userService.RegisterAsync(request);
    }
}
