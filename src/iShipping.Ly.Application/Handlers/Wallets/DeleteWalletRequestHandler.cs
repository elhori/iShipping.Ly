using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.Wallet;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Wallets
{
    public class DeleteWalletRequestHandler : IRequestHandler<DeleteWalletRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteWalletRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteWalletRequest request, CancellationToken cancellationToken)
        {
            var wallet = await _unitOfWork.Wallets.GetAsync(request.Id, cancellationToken);

            if (wallet is null)
                return false;

            await _unitOfWork.Wallets.RemoveAsync(wallet, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
