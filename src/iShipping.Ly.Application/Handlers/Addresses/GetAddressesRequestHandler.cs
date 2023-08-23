using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Address;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Addresses
{
    public class GetAddressesRequestHandler : IRequestHandler<GetAddressesRequest, Response<GetAddressesResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAddressesRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<GetAddressesResponse>> Handle(GetAddressesRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.Addresses.GetResponseAsync(request, cancellationToken);
    }
}
