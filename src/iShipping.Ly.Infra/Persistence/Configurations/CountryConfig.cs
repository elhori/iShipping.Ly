using iShipping.Ly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iShipping.Ly.Infra.Persistence.Configurations
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasMany(i => i.Addresses)
                .WithOne(i => i.Country)
                .HasForeignKey(i => i.CountryId);
        }
    }
}
