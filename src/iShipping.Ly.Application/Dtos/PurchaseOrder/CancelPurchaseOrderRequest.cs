using MediatR;

namespace iShipping.Ly.Application.Dtos.PurchaseOrder
{
    public record CancelPurchaseOrderRequest(int Id) : IRequest<bool>;
}
