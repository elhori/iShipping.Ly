using iShipping.Ly.Domain.Events.Requests;
using MediatR;

namespace iShipping.Ly.Application.Dtos.Wallet
{
    public record DepositeBalanceRequest(int WalletId, decimal Value) : IRequest<string>, IDepositeBalanceRequest;
}
