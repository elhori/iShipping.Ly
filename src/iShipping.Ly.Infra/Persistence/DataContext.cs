using iShipping.Ly.Domain.Entities;
using iShipping.Ly.Infra.Identity;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=iShippingLyDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
