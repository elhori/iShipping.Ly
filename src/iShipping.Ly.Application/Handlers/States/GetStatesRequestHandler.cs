using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.States;
using MediatR;

namespace iShipping.Ly.Application.Handlers.States
{
    public class GetStatesRequestHandler : IRequestHandler<GetStatesRequest, Response<GetStatesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStatesRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<GetStatesResponse>> Handle(GetStatesRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.States.GetResponseAsync(request, cancellationToken);
    }
}
