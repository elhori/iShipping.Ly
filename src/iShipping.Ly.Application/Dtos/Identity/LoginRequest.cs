using MediatR;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public record LoginRequest(string PhoneNumber, string Password) : IRequest<(Result, object)>;
}
