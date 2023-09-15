using iShipping.Ly.Application.Contracts.Repositories;

namespace iShipping.Ly.Infra.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        private ICountryRepository _countries;
        public ICountryRepository Countries
        {
            get
            {
                if (_countries != null)
                    return _countries;

                return _countries = new CountryRepository(_context);
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

        private IPurchaseOrderRepository _purchaseOrders;
        public IPurchaseOrderRepository PurchaseOrders
        {
            get
            {
                if (_purchaseOrders != null)
                    return _purchaseOrders;

                return _purchaseOrders = new PurchaseOrderRepository(_context);
            }
        }

        private IPurchaseOrderItemRepository _purchaseOrderItems;
        public IPurchaseOrderItemRepository PurchaseOrderItems
        {
            get
            {
                if (_purchaseOrderItems != null)
                    return _purchaseOrderItems;

                return _purchaseOrderItems = new PurchaseOrderItemRepository(_context);
            }
        }

        private IWalletRepository _wallets;
        public IWalletRepository Wallets
        {
            get
            {
                if (_wallets != null)
                    return _wallets;

                return _wallets = new WalletRepository(_context);
            }
        }

        private IEventRepository _events;
        public IEventRepository Events
        {
            get
            {
                if (_events != null)
                    return _events;

                return _events = new EventRepository(_context);
            }
        }

        public async Task BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync() => await _context.Database.CommitTransactionAsync();

        public async Task RollbackTransactionAsync() => await _context.Database.RollbackTransactionAsync();

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default) => await _context.SaveChangesAsync(cancellationToken);

        public void Dispose() => _context.Dispose();
    }
}
