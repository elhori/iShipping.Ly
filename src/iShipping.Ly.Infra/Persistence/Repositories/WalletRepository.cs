using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Domain.Entities;

namespace iShipping.Ly.Infra.Persistence.Repositories
{
    public class WalletRepository : AsyncRepository<Wallet>, IWalletRepository
    {
        private readonly DataContext _context;

        public WalletRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
