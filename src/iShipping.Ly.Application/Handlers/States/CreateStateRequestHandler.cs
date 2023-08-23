using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.States;
using iShipping.Ly.Application.Extensions;
using iShipping.Ly.Domain.Entities;
using MediatR;

namespace iShipping.Ly.Application.Handlers.States
{
    public class CreateStateRequestHandler : IRequestHandler<CreateStateRequest, GetStatesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateStateRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetStatesResponse> Handle(CreateStateRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.States.AnyAsync(i => i.Name == request.Name))
            {
                return null!;
            }

            var state = new State(request.ToModel());

            await _unitOfWork.States.AddAsync(state);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return state.ToResponse();
        }
    }
}
