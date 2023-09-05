using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class ResetPasswordRequestHandler : IRequestHandler<ResetPasswordRequest, Result>
    {
        private readonly IUserService _userService;

        public ResetPasswordRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
            => await _userService.ResetPasswordAsync(request);
    }
}
