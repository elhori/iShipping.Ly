using iShipping.Ly.Domain.Events.Requests;
using MediatR;

namespace iShipping.Ly.Application.Dtos.Wallet
{
    public record WithdrawBalanceRequest(int WalletId, decimal Value)
        : IRequest<string>, IWithdrawBalanceRequest;
}
