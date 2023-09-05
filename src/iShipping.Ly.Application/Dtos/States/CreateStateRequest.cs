using MediatR;

namespace iShipping.Ly.Application.Dtos.States
{
    public record CreateStateRequest(string Name, int Country) : IRequest<GetStatesResponse>;
}
