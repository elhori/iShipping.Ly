using iShipping.Ly.Domain.Enums;
using iShipping.Ly.Domain.Events.DataTypes;

namespace iShipping.Ly.Domain.Entities
{
    public abstract class Event
    {
        protected Event() { }

        public long Id { get; protected set; }

        public int AggregateId { get; protected set; }

        public string UserId { get; protected set; } = string.Empty;

        public string CustomerName { get; protected set; } = string.Empty;

        public long CustomerPhoneNumber { get; protected set; }

        public DateTime DateTime { get; protected set; }

        public EventType Type { get; protected set; }

        public int Sequence { get; protected set; }

        public int Version { get; protected set; }
    }

    public abstract class Event<TData> : Event where TData : IEventData
    {
        protected Event() { }

        protected Event(
            int aggregateId,
            int sequence,
            string userId,
            TData data,
            int version = 1
        )
        {
            AggregateId = aggregateId;
            Sequence = sequence;
            UserId = userId;
            Type = data.Type;
            Data = data;
            DateTime = DateTime.UtcNow;
            Version = version;
        }

        protected Event(
            int aggregateId,
            int sequence,
            string userId,
            TData data,
            DateTime date,
            int version = 1
        )
        {
            AggregateId = aggregateId;
            Sequence = sequence;
            UserId = userId;
            Type = data.Type;
            Data = data;
            DateTime = date;
            Version = version;
        }

        public TData Data { get; protected set; }
    }
}
