using MediatR;

namespace iShipping.Ly.Application.Dtos.Country
{
    public record DeleteCountryRequest(int Id) : IRequest<bool>;
}
