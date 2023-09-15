using iShipping.Ly.Domain.Entities;
using iShipping.Ly.Domain.Events;
using iShipping.Ly.Domain.Events.DataTypes;
using iShipping.Ly.Infra.Identity;
using iShipping.Ly.Infra.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace iShipping.Ly.Infra.Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<State> States { get; set; } = null!;
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; } = null!;
        public DbSet<Wallet> Wallets { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new GenericEventConfig<BalanceDepositedEvent, BalanceDepositedEventData>());

            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:shippingserver.database.windows.net,1433;Initial Catalog=shipping;Persist Security Info=False;User ID=elhori;Password=Admin@22;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
