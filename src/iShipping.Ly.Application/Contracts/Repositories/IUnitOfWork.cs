namespace iShipping.Ly.Application.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IAddressRepository Addresses { get; }

        ICityRepository Cities { get; }

        IStateRepository States { get; }

        ICountryRepository Countries { get; }

        IPurchaseOrderRepository PurchaseOrders { get; }

        IPurchaseOrderItemRepository PurchaseOrderItems { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();
    }
}
