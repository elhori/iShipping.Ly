using iShipping.Ly.Domain.Entities;
using iShipping.Ly.Domain.Events.DataTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace iShipping.Ly.Infra.Persistence.Configurations
{
    public class GenericEventConfig<TEntity, TData> : IEntityTypeConfiguration<TEntity>
        where TEntity : Event<TData>
        where TData : IEventData
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            builder.Property(e => e.Data).HasConversion(
                 v => JsonConvert.SerializeObject(v, jsonSerializerSettings),
                 v => JsonConvert.DeserializeObject<TData>(v)!
            ).HasColumnName("Data");
        }
    }
}
