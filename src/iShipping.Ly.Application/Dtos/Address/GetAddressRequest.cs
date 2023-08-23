using MediatR;

namespace iShipping.Ly.Application.Dtos.Address
{
    public record GetAddressRequest(int Id) : IRequest<GetAddressesResponse>;
}
