using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Address;
using iShipping.Ly.Application.Extensions;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Addresses
{
    public class UpdateAddressRequestHandler : IRequestHandler<UpdateAddressRequest, GetAddressesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAddressRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAddressesResponse> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
        {
            var address = await _unitOfWork.Addresses.GetAsync(request.Id, cancellationToken);

            if (address is null)
            {
                return null!;
            }

            address.Update(request.ToModel());

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return address.ToResponse();
        }
    }
}
