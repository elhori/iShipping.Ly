using MediatR;
using System.Text.Json.Serialization;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public class CreateAdminRequest : IRequest<Result>
    {
        public string UserName { get; set; } = string.Empty;

        public string? IdentificationCardNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        [JsonIgnore]
        public Constants.Roles Role { get; set; } = Constants.Roles.SuperAdmin;
    }
}
