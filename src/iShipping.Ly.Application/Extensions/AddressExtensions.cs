using iShipping.Ly.Application.Dtos.Address;
using iShipping.Ly.Domain.Entities;
using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Application.Extensions
{
    public static class AddressExtensions
    {
        public static AddressModel ToModel(this CreateAddressRequest request)
        {
            return new AddressModel(
                Id: 0,
                FirstName: request.FirstName,
                LastName: request.LastName,
                AddressLineOne: request.AddressLineOne,
                AddressLineTwo: request.AddressLineTwo,
                ZipCode: request.ZipCode,
                Phone: request.Phone,
                CityId: request.CityId);
        }

        public static AddressModel ToModel(this UpdateAddressRequest request)
        {
            return new AddressModel(
                Id: request.Id,
                FirstName: request.FirstName,
                LastName: request.LastName,
                AddressLineOne: request.AddressLineOne,
                AddressLineTwo: request.AddressLineTwo,
                ZipCode: request.ZipCode,
                Phone: request.Phone,
                CityId: request.CityId);
        }

        public static GetAddressesResponse ToResponse(this Address address)
        {
            return new GetAddressesResponse
            {
                Id = address.Id,
                FirstName = address.FirstName,
                LastName = address.LastName,
                AddressLineOne = address.AddressLineOne,
                AddressLineTwo = address.AddressLineTwo,
                ZipCode = address.ZipCode,
                Phone = address.Phone,
                CityId = address.CityId
            };
        }
    }
}
