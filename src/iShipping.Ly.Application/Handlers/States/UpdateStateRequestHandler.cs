using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.States;
using iShipping.Ly.Application.Extensions;
using MediatR;

namespace iShipping.Ly.Application.Handlers.States
{
    public class UpdateStateRequestHandler : IRequestHandler<UpdateStateRequest, GetStatesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStateRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetStatesResponse> Handle(UpdateStateRequest request, CancellationToken cancellationToken)
        {
            var state = await _unitOfWork.States.GetAsync(request.Id, cancellationToken);

            if (state is null)
            {
                return null!;
            }

            state.Update(request.ToModel());

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return state.ToResponse();
        }
    }
}
