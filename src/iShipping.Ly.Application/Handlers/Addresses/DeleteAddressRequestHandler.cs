using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Address;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Addresses
{
    public class DeleteAddressRequestHandler : IRequestHandler<DeleteAddressRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAddressRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteAddressRequest request, CancellationToken cancellationToken)
        {
            var address = await _unitOfWork.Addresses.GetAsync(request.Id, cancellationToken);

            if (address is null)
            {
                return false;
            }

            await _unitOfWork.Addresses.RemoveAsync(address, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
