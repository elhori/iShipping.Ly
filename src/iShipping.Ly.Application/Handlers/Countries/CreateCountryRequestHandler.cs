using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Country;
using iShipping.Ly.Application.Extensions;
using iShipping.Ly.Domain.Entities;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Countries
{
    public class CreateCountryRequestHandler : IRequestHandler<CreateCountryRequest, GetCountriesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCountryRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCountriesResponse> Handle(CreateCountryRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Countries.AnyAsync(c => c.Name == request.Name))
            {
                return null!;
            }

            var country = new Country(request.ToModel());

            await _unitOfWork.Countries.AddAsync(country);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return country.ToResponse();
        }
    }
}
