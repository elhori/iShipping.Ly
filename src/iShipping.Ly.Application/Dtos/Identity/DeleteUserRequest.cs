using MediatR;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public class DeleteUserRequest : IRequest<Result>
    {
        public string UserId { get; set; } = string.Empty;
    }
}
