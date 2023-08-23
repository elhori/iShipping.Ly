using MediatR;

namespace iShipping.Ly.Application.Dtos.City
{
    public record UpdateCityRequest(int Id, string Name, int AddressId, int StateId) : IRequest<GetCitiesResponse>;
}
