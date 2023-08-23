using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.City;
using iShipping.Ly.Application.Extensions;
using iShipping.Ly.Domain.Entities;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Cities
{
    public class CreateCityRequestHandler : IRequestHandler<CreateCityRequest, GetCitiesResponse>
    {
        private IUnitOfWork _unitOfWork;

        public CreateCityRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCitiesResponse> Handle(CreateCityRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Cities.AnyAsync(i => i.Name == request.Name))
            {
                return null!;
            }

            var city = new City(request.ToModel());

            await _unitOfWork.Cities.AddAsync(city, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return city.ToResponse();
        }
    }
}
