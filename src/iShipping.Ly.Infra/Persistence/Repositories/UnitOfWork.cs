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

                return _users = new UserRepository(_userManager, _config);
            }
        }

        private IAddressRepository _addresses;
        public IAddressRepository Addresses
        {
            get
            {
                if (_addresses != null)
                    return _addresses;

                return _addresses = new AddressRepository(_context);
            }
        }

        private ICityRepository _cities;
        public ICityRepository Cities
        {
            get
            {
                if (_cities != null)
                    return _cities;

                return _cities = new CityRepository(_context);
            }
        }

        private IStateRepository _states;
        public IStateRepository States
        {
            get
            {
                if (_states != null)
                    return _states;

                return _states = new StateRepository(_context);
            }
        }

        public async Task BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync() => await _context.Database.CommitTransactionAsync();

        public async Task RollbackTransactionAsync() => await _context.Database.RollbackTransactionAsync();

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);

        public void Dispose() => _context.Dispose();
    }
}
