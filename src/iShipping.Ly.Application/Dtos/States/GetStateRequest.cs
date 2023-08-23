using MediatR;

namespace iShipping.Ly.Application.Dtos.States
{
    public record GetStateRequest(int Id) : IRequest<GetStatesResponse>;
}
