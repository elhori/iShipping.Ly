using MediatR;

namespace iShipping.Ly.Application.Dtos.Country
{
    public record UpdateCountryRequest(int Id, string Name) : IRequest<GetCountriesResponse>;
}
