using MediatR;

namespace iShipping.Ly.Application.Dtos.Identity
{
    public class LoginRequest : IRequest<(Result, object)>
    {
        public string PhoneNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
