using MediatR;

namespace iShipping.Ly.Application.Dtos.Address
{
    public record DeleteAddressRequest(int Id) : IRequest<bool>;
}
