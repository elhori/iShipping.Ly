using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class CreateAdminRequestHandler : IRequestHandler<CreateAdminRequest, Result>
    {
        private readonly IUserService _userService;

        public CreateAdminRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(CreateAdminRequest request, CancellationToken cancellationToken)
            => await _userService.CreateAdminAsync(request);
    }
}
