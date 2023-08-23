using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Address;
using iShipping.Ly.Application.Extensions;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Addresses
{
    public class GetAddressRequestHandler : IRequestHandler<GetAddressRequest, GetAddressesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAddressRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAddressesResponse> Handle(GetAddressRequest request, CancellationToken cancellationToken)
        {
            var address = await _unitOfWork.Addresses.GetAsync(request.Id, cancellationToken);

            if (address == null)
            {
                return null!;
            }

            return address.ToResponse();
        }
    }
}
