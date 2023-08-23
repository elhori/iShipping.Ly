using MediatR;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public record ResetPasswordRequest(string Id, string NewPassword, string ConfirmPassword) : IRequest<Result>;
}
