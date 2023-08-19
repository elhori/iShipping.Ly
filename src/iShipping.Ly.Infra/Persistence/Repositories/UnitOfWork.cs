using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Infra.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace iShipping.Ly.Infra.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;

        public UnitOfWork(DataContext context, UserManager<AppUser> userManager, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
        }

        private IUserRepository _users;
        public IUserRepository Users
        {
            get
            {
                if (_users != null)
                    return _users;

                return _users = new UserRepository(_userManager, _config, _context);
            }
        }

        public async Task BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync() => await _context.Database.CommitTransactionAsync();

        public async Task RollbackTransactionAsync() => await _context.Database.RollbackTransactionAsync();

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);

        public void Dispose() => _context.Dispose();
    }
}
