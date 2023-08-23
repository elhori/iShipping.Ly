using MediatR;

namespace iShipping.Ly.Application.Dtos.City
{
    public record DeleteCityRequest(int Id) : IRequest<bool>;
}
