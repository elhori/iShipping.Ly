using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos.Wallet;
using iShipping.Ly.Domain.Entities;
using MediatR;

namespace iShipping.Ly.Application.Handlers.Wallets
{
    public class PayRequestHandler : IRequestHandler<PayRequest, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommitEventService _commitEventService;

        public PayRequestHandler(IUnitOfWork unitOfWork, ICommitEventService commitEventService)
        {
            _unitOfWork = unitOfWork;
            _commitEventService = commitEventService;
        }

        public async Task<string> Handle(PayRequest request, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Events.GetAllByAggregateIdAsync(request.WalletId, cancellationToken);

            if (!events.Any())
                throw new Exception("المحفظة غير موجودة");

            var wallet = Wallet.LoadFromHistory(events);

            wallet.Pay(request);

            await _commitEventService.CommitNewEventAsync(wallet);

            return $"تم الشراء بقيمة {request.Value}";
        }
    }
}
