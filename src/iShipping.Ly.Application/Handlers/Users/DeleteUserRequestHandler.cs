using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, Result>
    {
        private readonly IUserService _userService;

        public DeleteUserRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
            => await _userService.RemoveUserAsync(request.UserId);
    }
}
