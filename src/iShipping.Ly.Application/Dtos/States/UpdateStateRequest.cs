using MediatR;

namespace iShipping.Ly.Application.Dtos.States
{
    public record UpdateStateRequest(int Id, string Name) : IRequest<GetStatesResponse>;
}
