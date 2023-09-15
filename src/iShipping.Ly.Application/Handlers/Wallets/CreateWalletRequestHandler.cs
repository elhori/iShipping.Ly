using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Wallet;
using iShipping.Ly.Application.Extensions;
using iShipping.Ly.Domain.Entities;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Wallets
{
    public class CreateWalletRequestHandler : IRequestHandler<CreateWalletRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateWalletRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateWalletRequest request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.Wallets.AnyAsync(i => i.CustomerId == request.CustomerId, cancellationToken))
                return false;

            var wallet = new Wallet(request.ToModel());

            await _unitOfWork.Wallets.AddAsync(wallet, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
