using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.City;
using iShipping.Ly.Application.Extensions;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Cities
{
    public class UpdateCityRequestHandler : IRequestHandler<UpdateCityRequest, GetCitiesResponse>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateCityRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCitiesResponse> Handle(UpdateCityRequest request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.Cities.GetAsync(request.Id, cancellationToken);

            if (city == null)
            {
                return null!;
            }

            city.Update(request.ToModel());

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return city.ToResponse();
        }
    }
}
