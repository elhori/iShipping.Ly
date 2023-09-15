using iShipping.Ly.Domain.Enums;
using System.Text.Json.Serialization;

namespace iShipping.Ly.Domain.Events.DataTypes
{
    public interface IEventData
    {
        [JsonIgnore]
        EventType Type { get; }
    }
}
