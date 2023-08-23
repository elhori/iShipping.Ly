using MediatR;

namespace iShipping.Ly.Application.Dtos.City
{
    public record CreateCityRequest(string Name, int AddressId, int StateId) : IRequest<GetCitiesResponse>;
}
