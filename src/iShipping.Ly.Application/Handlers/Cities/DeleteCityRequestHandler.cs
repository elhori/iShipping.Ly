using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.City;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Cities
{
    public class DeleteCityRequestHandler : IRequestHandler<DeleteCityRequest, bool>
    {
        private IUnitOfWork _unitOfWork;

        public DeleteCityRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCityRequest request, CancellationToken cancellationToken)
        {
            var city = await _unitOfWork.Cities.GetAsync(request.Id, cancellationToken);

            if (city is null)
            {
                return false;
            }

            await _unitOfWork.Cities.RemoveAsync(city, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
