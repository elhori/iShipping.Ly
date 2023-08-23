using MediatR;
using System.Text.Json.Serialization;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public record RegisterRequest(string UserName,
                              string? IdentificationCardNumber,
                              string Password,
                              string Email,
                              string PhoneNumber,
                              string FirstName,
                              string LastName,
                              [property: JsonIgnore] Constants.Roles Role) : IRequest<Result>;
}
