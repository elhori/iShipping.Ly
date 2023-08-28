using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class UpdateUserProfileRequestHandler : IRequestHandler<UpdateUserProfileRequest, Result>
    {
        private readonly IUserService _userService;

        public UpdateUserProfileRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(UpdateUserProfileRequest request, CancellationToken cancellationToken)
            => await _userService.UpdateUserProfileAsync(request);
    }
}
