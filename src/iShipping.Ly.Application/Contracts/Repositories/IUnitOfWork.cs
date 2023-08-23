namespace iShipping.Ly.Application.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        IAddressRepository Addresses { get; }

        ICityRepository Cities { get; }

        IStateRepository States { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();
    }
}
