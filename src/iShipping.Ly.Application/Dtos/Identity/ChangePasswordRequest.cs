using MediatR;
using System.Text.Json.Serialization;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public record ChangePasswordRequest([property: JsonIgnore] string Id,
                                    string OldPassword,
                                    string NewPassword,
                                    string ConfirmPassword) : IRequest<Result>;
}
