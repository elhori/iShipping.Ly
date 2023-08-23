using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Address;
using iShipping.Ly.Application.Extensions;
using iShipping.Ly.Domain.Entities;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Addresses
{
    public class CreateAddressRequestHandler : IRequestHandler<CreateAddressRequest, GetAddressesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAddressRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAddressesResponse> Handle(CreateAddressRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Addresses.AnyAsync(i => i.FirstName == request.FirstName && i.LastName == request.LastName))
            {
                return null!;
            }

            var address = new Address(request.ToModel());

            await _unitOfWork.Addresses.AddAsync(address);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return address.ToResponse();
        }
    }
}
