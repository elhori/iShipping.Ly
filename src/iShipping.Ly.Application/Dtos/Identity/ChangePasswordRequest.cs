using MediatR;
using System.Text.Json.Serialization;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public class ChangePasswordRequest : IRequest<Result>
    {
        [JsonIgnore]
        public string Id { get; set; } = string.Empty;

        public string OldPassword { get; set; } = string.Empty;

        public string NewPassword { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
