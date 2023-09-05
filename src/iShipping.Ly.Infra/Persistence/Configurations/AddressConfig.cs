using iShipping.Ly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iShipping.Ly.Infra.Persistence.Configurations
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasOne(i => i.City)
                .WithMany(i => i.Addresses)
                .HasForeignKey(i => i.CityId);

            builder.HasOne(i => i.Country)
                .WithMany(i => i.Addresses)
                .HasForeignKey(i => i.CountryId);
        }
    }
}
