using iShipping.Ly.Domain.Enums;

namespace iShipping.Ly.Domain.Events.DataTypes
{
    public record BalanceWithdrawEventData(decimal Value) : IEventData
    {
        public EventType Type => EventType.BalanceWithdraw;
    }
}
