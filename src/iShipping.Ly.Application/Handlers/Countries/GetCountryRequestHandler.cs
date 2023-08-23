using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Country;
using iShipping.Ly.Application.Extensions;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Countries
{
    public class GetCountryRequestHandler : IRequestHandler<GetCountryRequest, GetCountriesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCountryRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCountriesResponse> Handle(GetCountryRequest request, CancellationToken cancellationToken)
        {
            var country = await _unitOfWork.Countries.GetAsync(request.Id, cancellationToken);

            if (country == null)
            {
                return null!;
            }

            return country.ToResponse();
        }
    }
}
