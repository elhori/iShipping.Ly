using MediatR;
using System.Text.Json.Serialization;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public record UpdateUserProfileRequest([property: JsonIgnore] string Id,
                                       string? UserName,
                                       string? Email,
                                       string? PhoneNumber,
                                       string? FirstName,
                                       string? LastName,
                                       string IdentificationCardNumber,
                                       [property: JsonIgnore] string? ProfilePicture) : IRequest<Result>;
}
