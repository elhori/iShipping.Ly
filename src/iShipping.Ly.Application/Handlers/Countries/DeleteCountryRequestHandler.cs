using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Country;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Countries
{
    public class DeleteCountryRequestHandler : IRequestHandler<DeleteCountryRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCountryRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCountryRequest request, CancellationToken cancellationToken)
        {
            var country = await _unitOfWork.Countries.GetAsync(request.Id, cancellationToken);

            if (country is null)
            {
                return false;
            }

            await _unitOfWork.Countries.RemoveAsync(country, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
