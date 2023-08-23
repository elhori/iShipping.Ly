using MediatR;

namespace iShipping.Ly.Application.Dtos.Country
{
    public record GetCountryRequest(int Id) : IRequest<GetCountriesResponse>;
}
