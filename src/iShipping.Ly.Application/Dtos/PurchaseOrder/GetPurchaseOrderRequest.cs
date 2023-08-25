using MediatR;

namespace iShipping.Ly.Application.Dtos.PurchaseOrder
{
    public record GetPurchaseOrderRequest(int Id) : IRequest<GetPurchaseOrdersResponse>;
}
