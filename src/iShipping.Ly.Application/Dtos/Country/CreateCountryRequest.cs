using MediatR;

namespace iShipping.Ly.Application.Dtos.Country
{
    public record CreateCountryRequest(string Name) : IRequest<GetCountriesResponse>;
}
