using iShipping.Ly.Domain.Enums;

namespace iShipping.Ly.Domain.Models
{
    public record PurchaseOrderModel(
        int Id,
        PurchaseOrderStatus Status,
        string CustomerId);
}
