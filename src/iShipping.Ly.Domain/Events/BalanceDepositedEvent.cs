using iShipping.Ly.Domain.Entities;
using iShipping.Ly.Domain.Events.DataTypes;

namespace iShipping.Ly.Domain.Events
{
    public class BalanceDepositedEvent : Event<BalanceDepositedEventData>
    {
        private BalanceDepositedEvent() { }

        public BalanceDepositedEvent(
            int AggregateId,
            string UserId,
            DateTime DateTime,
            BalanceDepositedEventData Data,
            int Sequence,
            int Version = 1
            ) : base(AggregateId, Sequence, UserId, Data, DateTime, Version)
        {
        }
    }
}
