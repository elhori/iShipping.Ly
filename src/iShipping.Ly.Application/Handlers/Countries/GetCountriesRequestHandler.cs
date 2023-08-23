using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Country;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Countries
{
    public class GetCountriesRequestHandler : IRequestHandler<GetCountriesRequest, Response<GetCountriesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCountriesRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<GetCountriesResponse>> Handle(GetCountriesRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.Countries.GetResponseAsync(request, cancellationToken);
    }
}
