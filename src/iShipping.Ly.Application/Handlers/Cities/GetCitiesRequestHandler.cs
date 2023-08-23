using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.City;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Cities
{
    public class GetCitiesRequestHandler : IRequestHandler<GetCitiesRequest, Response<GetCitiesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCitiesRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<GetCitiesResponse>> Handle(GetCitiesRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.Cities.GetResponseAsync(request, cancellationToken);
    }
}
