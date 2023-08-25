using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Domain.Entities;

namespace iShipping.Ly.Infra.Persistence.Repositories
{
    public class PurchaseOrderItemRepository : AsyncRepository<PurchaseOrderItem>, IPurchaseOrderItemRepository
    {
        private readonly DataContext _context;

        public PurchaseOrderItemRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
