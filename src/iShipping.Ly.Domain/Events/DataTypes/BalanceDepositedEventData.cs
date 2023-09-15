using iShipping.Ly.Domain.Enums;

namespace iShipping.Ly.Domain.Events.DataTypes
{
    public record BalanceDepositedEventData(decimal Value) : IEventData
    {
        public EventType Type => EventType.BalanceDeposited;
    }
}
