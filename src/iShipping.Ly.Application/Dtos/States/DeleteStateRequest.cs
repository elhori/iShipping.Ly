using MediatR;

namespace iShipping.Ly.Application.Dtos.States
{
    public record DeleteStateRequest(int Id) : IRequest<bool>;
}
