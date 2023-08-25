using iShipping.Ly.Domain.Enums;
using MediatR;

namespace iShipping.Ly.Application.Dtos.PurchaseOrder
{
    public record GetPurchaseOrdersRequest(int CurrentPage = 1, int PageSize = 25) : IRequest<Response<GetPurchaseOrdersResponse>>;

    public class GetPurchaseOrdersResponse
    {
        public int Id { get; set; }

        public decimal OrderPrice { get; set; }

        public PurchaseOrderStatus Status { get; set; }

        public string CustomerId { get; set; } = string.Empty;

        public string CustomerName { get; set; } = string.Empty;

        public List<GetPurchaseOrderItemsResponse> Items { get; set; } = null!;
    }

    public class GetPurchaseOrderItemsResponse
    {
        public int Id { get; set; }

        public string ProductLink { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal ShippingPriceInDollar { get; set; }

        public string ColorAndSize { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public string TrackingNumber { get; set; } = string.Empty;
    }
}
