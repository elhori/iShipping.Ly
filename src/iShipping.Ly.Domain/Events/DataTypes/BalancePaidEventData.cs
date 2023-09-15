using iShipping.Ly.Domain.Enums;

namespace iShipping.Ly.Domain.Events.DataTypes
{
    public record BalancePaidEventData(
        decimal Value,
        string Description) : IEventData
    {
        private BalancePaidEventData() : this(default, default!) { }

        public EventType Type => EventType.BalancePaid;
    }
}
