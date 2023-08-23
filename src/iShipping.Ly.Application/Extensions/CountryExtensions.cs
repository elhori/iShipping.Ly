using iShipping.Ly.Application.Dtos.Country;
using iShipping.Ly.Domain.Entities;
using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Application.Extensions
{
    public static class CountryExtensions
    {
        public static CountryModel ToModel(this CreateCountryRequest request)
        {
            return new CountryModel(Id: 0, Name: request.Name);
        }

        public static CountryModel ToModel(this UpdateCountryRequest request)
        {
            return new CountryModel(Id: request.Id, Name: request.Name);
        }

        public static GetCountriesResponse ToResponse(this Country state)
        {
            return new GetCountriesResponse
            {
                Id = state.Id,
                Name = state.Name
            };
        }
    }
}
