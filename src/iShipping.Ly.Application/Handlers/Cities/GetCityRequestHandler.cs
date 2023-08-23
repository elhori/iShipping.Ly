using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.City;
using iShipping.Ly.Application.Extensions;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Cities
{
    public class GetCityRequestHandler : IRequestHandler<GetCityRequest, GetCitiesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCityRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCitiesResponse> Handle(GetCityRequest request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.Cities.GetAsync(request.Id, cancellationToken);

            if (city == null)
            {
                return null!;
            }

            return city.ToResponse();
        }
    }
}
