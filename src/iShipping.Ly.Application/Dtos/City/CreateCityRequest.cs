using MediatR;

namespace iShipping.Ly.Application.Dtos.City
{
    public record CreateCityRequest(string Name, int StateId) : IRequest<GetCitiesResponse>;
}
