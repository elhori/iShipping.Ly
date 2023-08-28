using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, Response<GetUsersResponse>>
    {
        private readonly IUserService _userService;

        public GetUsersRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Response<GetUsersResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
            => await _userService.GetUsersAsync(request, cancellationToken);
    }
}
