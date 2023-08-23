using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.States;
using iShipping.Ly.Application.Extensions;
using MediatR;

namespace iShipping.Ly.Application.Handlers.States
{
    public class GetStateRequestHandler : IRequestHandler<GetStateRequest, GetStatesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStateRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetStatesResponse> Handle(GetStateRequest request, CancellationToken cancellationToken)
        {
            var state = await _unitOfWork.States.GetAsync(request.Id, cancellationToken);

            if (state == null)
            {
                return null!;
            }

            return state.ToResponse();
        }
    }
}
