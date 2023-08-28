using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class ChangePasswordRequestHandler : IRequestHandler<ChangePasswordRequest, Result>
    {
        private readonly IUserService _userService;

        public ChangePasswordRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
            => await _userService.ChangePasswordAsync(request);
    }
}
