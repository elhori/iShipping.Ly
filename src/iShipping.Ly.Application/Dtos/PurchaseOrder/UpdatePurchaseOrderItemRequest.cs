using MediatR;

namespace iShipping.Ly.Application.Dtos.PurchaseOrder
{
    public record UpdatePurchaseOrderItemRequest(
        int Id,
        string ProductLink,
        int Quantity,
        decimal Price,
        decimal ShippingPriceInDollar,
        string ColorAndSize,
        string Note) : IRequest<GetPurchaseOrderItemsResponse>;
}
