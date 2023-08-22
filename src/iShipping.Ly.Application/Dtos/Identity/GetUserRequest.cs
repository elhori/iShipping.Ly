using MediatR;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public record GetUserRequest(string userId) : IRequest<GetUsersResponse>;
}
