using MediatR;
using System.Text.Json.Serialization;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public class UpdateUserProfileRequest : IRequest<Result>
    {
        [JsonIgnore]
        public string Id { get; set; } = string.Empty;

        public string? UserName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; } = string.Empty;

        public string? FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; } = string.Empty;

        public string IdentificationCardNumber { get; set; } = string.Empty;

        [JsonIgnore]
        public string? ProfilePicture { get; set; } = string.Empty;
    }
}
