using iShipping.Ly.Domain.Entities;
using iShipping.Ly.Domain.Enums;
using iShipping.Ly.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iShipping.Ly.Infra.Persistence.Configurations
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasIndex(e => new { e.AggregateId, e.Sequence }).IsUnique();

            builder.Property(e => e.UserId).HasMaxLength(Config.StringId);

            builder.Property(e => e.Type).HasMaxLength(Config.StringId).HasConversion<string>();

            builder.HasDiscriminator(e => e.Type)
                .HasValue<BalanceDepositedEvent>(EventType.BalanceDeposited);
        }
    }
}
