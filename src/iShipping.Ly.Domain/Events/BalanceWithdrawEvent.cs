using iShipping.Ly.Domain.Entities;
using iShipping.Ly.Domain.Events.DataTypes;

namespace iShipping.Ly.Domain.Events
{
    public class BalanceWithdrawEvent : Event<BalanceWithdrawEventData>
    {
        private BalanceWithdrawEvent() { }

        public BalanceWithdrawEvent(
            int AggregateId,
            string UserId,
            DateTime DateTime,
            BalanceWithdrawEventData Data,
            int Sequence,
            int Version = 1
            ) : base(AggregateId, Sequence, UserId, Data, DateTime, Version)
        {
        }
    }
}
