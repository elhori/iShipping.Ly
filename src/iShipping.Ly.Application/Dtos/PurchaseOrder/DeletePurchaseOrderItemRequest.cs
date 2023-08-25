using MediatR;

namespace iShipping.Ly.Application.Dtos.PurchaseOrder
{
    public record DeletePurchaseOrderItemRequest(int Id) : IRequest<bool>;
}
