using MediatR;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public class ResetPasswordRequest : IRequest<Result>
    {
        public string Id { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
