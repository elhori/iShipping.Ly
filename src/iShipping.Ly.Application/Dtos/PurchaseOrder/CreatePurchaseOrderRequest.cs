using MediatR;

namespace iShipping.Ly.Application.Dtos.PurchaseOrder
{
    public record CreatePurchaseOrderRequest(
        string CustomerId,
        List<CreatePurchaseOrderItemRequest> Items) : IRequest<bool>;

    public record CreatePurchaseOrderItemRequest(
        string ProductLink,
        int Quantity,
        decimal Price,
        decimal ShippingPriceInDollar,
        string ColorAndSize,
        string Note,
        int PurchaseOrderId) : IRequest<bool>;
}
