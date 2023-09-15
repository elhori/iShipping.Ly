using iShipping.Ly.Domain.Entities;

namespace iShipping.Ly.Application.Contracts.Services
{
    public interface ICommitEventService
    {
        Task CommitNewEventAsync(Wallet wallet);
    }
}
