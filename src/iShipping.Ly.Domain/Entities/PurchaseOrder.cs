using iShipping.Ly.Domain.Enums;
using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Domain.Entities
{
    public class PurchaseOrder
    {
        private PurchaseOrder() { }

        public PurchaseOrder(PurchaseOrderModel model)
        {
            CustomerId = model.CustomerId;
        }

        public int Id { get; private set; }

        public decimal OrderPrice { get; private set; }

        public PurchaseOrderStatus Status { get; private set; } = PurchaseOrderStatus.Pending;

        public string CustomerId { get; private set; } = string.Empty;

        private readonly HashSet<PurchaseOrderItem> _items = new();
        public IReadOnlyCollection<PurchaseOrderItem> Items => _items;

        public void UpdateStatus(PurchaseOrderStatus status)
        {
            Status = status;
        }

        public void CalculateOrderPrice(decimal orderPrice)
        {
            OrderPrice = orderPrice;
        }
    }
}
