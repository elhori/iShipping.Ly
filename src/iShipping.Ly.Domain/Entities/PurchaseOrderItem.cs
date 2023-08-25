using iShipping.Ly.Domain.Models;

namespace iShipping.Ly.Domain.Entities
{
    public class PurchaseOrderItem
    {
        private PurchaseOrderItem() { }

        public PurchaseOrderItem(PurchaseOrderItemModel model)
        {
            ProductLink = model.ProductLink;
            Quantity = model.Quantity;
            Price = model.Price;
            TotalPrice = model.Price * model.Quantity;
            ShippingPriceInDollar = model.ShippingPriceInDollar;
            ColorAndSize = model.ColorAndSize;
            Note = model.Note;
        }

        public int Id { get; private set; }

        public string ProductLink { get; private set; } = string.Empty;

        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        public decimal TotalPrice { get; private set; }

        public decimal ShippingPriceInDollar { get; private set; }

        public string ColorAndSize { get; private set; } = "لا يوجد";

        public string Note { get; private set; } = "لا يوجد";

        public string TrackingNumber { get; private set; } = string.Empty;

        public void GenerateTrackingNumber()
        {
            TrackingNumber = Guid.NewGuid().ToString("N").Substring(0, 10);
        }

        public void Update(PurchaseOrderItemModel model)
        {
            ProductLink = model.ProductLink;
            Quantity = model.Quantity;
            Price = model.Price;
            TotalPrice = model.Price * model.Quantity;
            ShippingPriceInDollar = model.ShippingPriceInDollar;
            ColorAndSize = model.ColorAndSize;
            Note = model.Note;
        }
    }
}
