namespace iShipping.Ly.Domain.Models
{
    public record PurchaseOrderItemModel(
        int Id,
        string ProductLink,
        int Quantity,
        decimal Price,
        decimal ShippingPriceInDollar,
        string ColorAndSize,
        string Note);
}
