using iShipping.Ly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iShipping.Ly.Infra.Persistence.Configurations
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasMany(i => i.Addresses)
                .WithOne(i => i.City)
                .HasForeignKey(i => i.CityId);

            builder.HasOne(i => i.State)
                .WithMany(i => i.Cities)
                .HasForeignKey(i => i.StateId);
        }
    }
}
