using iShipping.Ly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iShipping.Ly.Infra.Persistence.Configurations
{
    public class StateConfig : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasMany(i => i.Cities)
                .WithOne(i => i.State)
                .HasForeignKey(i => i.StateId);

            builder.HasOne(i => i.Country)
                .WithMany(i => i.States)
                .HasForeignKey(i => i.CountryId);
        }
    }
}
