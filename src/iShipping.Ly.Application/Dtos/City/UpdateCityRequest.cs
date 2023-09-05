using MediatR;

namespace iShipping.Ly.Application.Dtos.City
{
    public record UpdateCityRequest(int Id, string Name, int? StateId) : IRequest<GetCitiesResponse>;
}
