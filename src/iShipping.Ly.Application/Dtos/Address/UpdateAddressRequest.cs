using MediatR;

namespace iShipping.Ly.Application.Dtos.Address
{
    public record UpdateAddressRequest(int Id,
                                   string FirstName,
                                   string LastName,
                                   string AddressLineOne,
                                   string AddressLineTwo,
                                   string ZipCode,
                                   string Phone,
                                   int CityId) : IRequest<GetAddressesResponse>;
}
