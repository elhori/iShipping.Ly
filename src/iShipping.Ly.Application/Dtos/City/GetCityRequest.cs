using MediatR;

namespace iShipping.Ly.Application.Dtos.City
{
    public record GetCityRequest(int Id) : IRequest<GetCitiesResponse>;
}
