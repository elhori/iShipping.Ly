using iShipping.Ly.Domain.Events;
using iShipping.Ly.Domain.Events.DataTypes;
using iShipping.Ly.Domain.Events.Requests;

namespace iShipping.Ly.Domain.Extensions
{
    public static class EventExtensions
    {
        public static BalanceDepositedEvent ToEvent(this IDepositeBalanceRequest request, int sequence)
            => new(
                AggregateId: request.WalletId,
                UserId: string.Empty,
                DateTime: DateTime.UtcNow,
                Data: new BalanceDepositedEventData(request.Value),
                sequence);

        public static BalanceWithdrawEvent ToEvent(this IWithdrawBalanceRequest request, int sequence)
            => new(
                AggregateId: request.WalletId,
                UserId: string.Empty,
                DateTime: DateTime.UtcNow,
                Data: new BalanceWithdrawEventData(request.Value),
                sequence);

        public static BalancePaidEvent ToEvent(this IPayRequest request, int sequence)
            => new(
                AggregateId: request.WalletId,
                UserId: string.Empty,
                DateTime: DateTime.UtcNow,
                Data: new BalancePaidEventData(request.Value, request.Description),
                sequence);
    }
}
