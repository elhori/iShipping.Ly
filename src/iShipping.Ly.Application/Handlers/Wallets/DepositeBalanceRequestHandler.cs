using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos.Wallet;
using iShipping.Ly.Domain.Entities;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Wallets
{
    public class DepositeBalanceRequestHandler : IRequestHandler<DepositeBalanceRequest, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommitEventService _commitEventService;

        public DepositeBalanceRequestHandler(IUnitOfWork unitOfWork, ICommitEventService commitEventService)
        {
            _unitOfWork = unitOfWork;
            _commitEventService = commitEventService;
        }

        public async Task<string> Handle(DepositeBalanceRequest request, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Events.GetAllByAggregateIdAsync(request.WalletId, cancellationToken);

            if (!events.Any())
                throw new Exception("المحفظة غير موجودة");

            var wallet = Wallet.LoadFromHistory(events);

            wallet.Deposite(request);

            await _commitEventService.CommitNewEventAsync(wallet);

            return $"تم ايداع القيمة {request.Value} بنجاح";
        }
    }
}
