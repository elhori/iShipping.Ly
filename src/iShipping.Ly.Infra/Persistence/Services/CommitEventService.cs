using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Domain.Entities;

namespace iShipping.Ly.Infra.Persistence.Services
{
    public class CommitEventService : ICommitEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommitEventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CommitNewEventAsync(Wallet wallet)
        {
            var newEvents = wallet.GetUncommittedEvents();

            await _unitOfWork.Events.AddRangeAync(newEvents);

            await _unitOfWork.SaveChangesAsync();

            wallet.MarkChangesAsCommited();
        }
    }
}
