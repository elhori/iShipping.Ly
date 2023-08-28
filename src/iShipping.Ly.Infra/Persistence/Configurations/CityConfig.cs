using iShipping.Ly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iShipping.Ly.Infra.Persistence.Configurations
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasOne(i => i.Address)
                .WithOne(i => i.City)
                .HasForeignKey<City>(i => i.AddressId);

            builder.HasOne(i => i.State)
                .WithOne(i => i.City)
                .HasForeignKey<City>(i => i.StateId);
        }
    }
}
