using MediatR;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public record DeleteUserRequest(string UserId) : IRequest<Result>;
}
