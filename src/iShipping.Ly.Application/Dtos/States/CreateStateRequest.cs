using MediatR;

namespace iShipping.Ly.Application.Dtos.States
{
    public record CreateStateRequest(string Name, int CountryId) : IRequest<GetStatesResponse>;
}
