using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.States;
using MediatR;

namespace iShipping.Ly.Application.Handlers.States
{
    public class DeleteStateRequestHandler : IRequestHandler<DeleteStateRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStateRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteStateRequest request, CancellationToken cancellationToken)
        {
            var state = await _unitOfWork.States.GetAsync(request.Id, cancellationToken);

            if (state is null)
            {
                return false;
            }

            await _unitOfWork.States.RemoveAsync(state, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
