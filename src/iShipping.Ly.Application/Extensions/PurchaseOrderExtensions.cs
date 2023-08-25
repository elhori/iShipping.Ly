using iShipping.Ly.Application.Dtos.PurchaseOrder;
using iShipping.Ly.Domain.Entities;
using iShipping.Ly.Domain.Enums;
using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Application.Extensions
{
    public static class PurchaseOrderExtensions
    {
        public static PurchaseOrderModel ToModel(this CreatePurchaseOrderRequest request)
        {
            return new PurchaseOrderModel(Id: 0,
                Status: PurchaseOrderStatus.Pending,
                CustomerId: request.CustomerId);
        }

        public static PurchaseOrderItemModel ToModel(this CreatePurchaseOrderItemRequest request)
        {
            return new PurchaseOrderItemModel(Id: 0,
                ProductLink: request.ProductLink,
                Quantity: request.Quantity,
                Price: request.Price,
                ShippingPriceInDollar: request.ShippingPriceInDollar,
                ColorAndSize: request.ColorAndSize,
                Note: request.Note);
        }

        public static PurchaseOrderItemModel ToModel(this UpdatePurchaseOrderItemRequest request)
        {
            return new PurchaseOrderItemModel(Id: 0,
                ProductLink: request.ProductLink,
                Quantity: request.Quantity,
                Price: request.Price,
                ShippingPriceInDollar: request.ShippingPriceInDollar,
                ColorAndSize: request.ColorAndSize,
                Note: request.Note);
        }

        public static GetPurchaseOrderItemsResponse ToResponse(this PurchaseOrderItem purchaseOrderItem)
        {
            return new GetPurchaseOrderItemsResponse
            {
                Id = purchaseOrderItem.Id,
                ColorAndSize = purchaseOrderItem.ColorAndSize,
                Note = purchaseOrderItem.Note,
                Price = purchaseOrderItem.Price,
                ProductLink = purchaseOrderItem.ProductLink,
                Quantity = purchaseOrderItem.Quantity,
                ShippingPriceInDollar = purchaseOrderItem.ShippingPriceInDollar,
                TotalPrice = purchaseOrderItem.TotalPrice,
                TrackingNumber = purchaseOrderItem.TrackingNumber
            };
        }

        public static GetPurchaseOrdersResponse ToResponse(this PurchaseOrder purchaseOrder)
        {
            return new GetPurchaseOrdersResponse
            {
                Id = purchaseOrder.Id,
                OrderPrice = purchaseOrder.OrderPrice,
                Status = purchaseOrder.Status,
                CustomerId = purchaseOrder.CustomerId,
                Items = purchaseOrder.Items.Select(i => new GetPurchaseOrderItemsResponse
                {
                    Id = i.Id,
                    ColorAndSize = i.ColorAndSize,
                    Note = i.Note,
                    Price = i.Price,
                    ProductLink = i.ProductLink,
                    Quantity = i.Quantity,
                    ShippingPriceInDollar = i.ShippingPriceInDollar,
                    TotalPrice = i.TotalPrice,
                    TrackingNumber = i.TrackingNumber

                }).ToList()
            };
        }
    }
}
