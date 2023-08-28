using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Identity;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Users
{
    public class SearchUsersRequestHandler : IRequestHandler<SearchUsersRequest, Response<GetUsersResponse>>
    {
        private readonly IUserService _userService;

        public SearchUsersRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Response<GetUsersResponse>> Handle(SearchUsersRequest request, CancellationToken cancellationToken)
            => await _userService.SearchAsync(request, cancellationToken);
    }
}
