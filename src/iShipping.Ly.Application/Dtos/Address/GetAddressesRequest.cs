using MediatR;

namespace iShipping.Ly.Application.Dtos.Address
{
    public record GetAddressesRequest(int CurrentPage = 1, int PageSize = 25) : IRequest<Response<GetAddressesResponse>>;

    public class GetAddressesResponse
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string AddressLineOne { get; set; } = string.Empty;

        public string AddressLineTwo { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;

        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;

        public int StateId { get; set; }
        public string StateName { get; set; } = string.Empty;
    }
}
