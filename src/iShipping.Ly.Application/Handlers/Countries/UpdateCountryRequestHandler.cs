using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Country;
using iShipping.Ly.Application.Extensions;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Countries
{
    public class UpdateCountryRequestHandler : IRequestHandler<UpdateCountryRequest, GetCountriesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCountryRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCountriesResponse> Handle(UpdateCountryRequest request, CancellationToken cancellationToken)
        {
            var country = await _unitOfWork.Countries.GetAsync(request.Id, cancellationToken);

            if (country is null)
            {
                return null!;
            }

            country.Update(request.ToModel());

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return country.ToResponse();
        }
    }
}
