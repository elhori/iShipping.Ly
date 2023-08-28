using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, GetUsersResponse>
    {
        private readonly IUserService _userService;

        public GetUserRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUsersResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
            => await _userService.GetUserAsync(request.userId, cancellationToken);
    }
}
