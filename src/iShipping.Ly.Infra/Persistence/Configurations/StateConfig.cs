using iShipping.Ly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iShipping.Ly.Infra.Persistence.Configurations
{
    public class StateConfig : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasOne(i => i.City)
                .WithOne(i => i.State)
                .HasForeignKey<State>(i => i.CityId);
        }
    }
}
