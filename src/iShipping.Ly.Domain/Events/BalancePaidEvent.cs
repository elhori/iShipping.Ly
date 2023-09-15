using iShipping.Ly.Domain.Entities;
using iShipping.Ly.Domain.Events.DataTypes;

namespace iShipping.Ly.Domain.Events
{
    public class BalancePaidEvent : Event<BalancePaidEventData>
    {
        private BalancePaidEvent() { }

        public BalancePaidEvent(
            int AggregateId,
            string UserId,
            DateTime DateTime,
            BalancePaidEventData Data,
            int Sequence,
            int Version = 1
            ) : base(AggregateId, Sequence, UserId, Data, DateTime, Version)
        {
        }
    }
}
