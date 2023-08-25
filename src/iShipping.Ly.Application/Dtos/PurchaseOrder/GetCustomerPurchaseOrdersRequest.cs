using MediatR;

namespace iShipping.Ly.Application.Dtos.PurchaseOrder
{
    public record GetCustomerPurchaseOrdersRequest(string CustomerId, int CurrentPage = 1, int PageSize = 25)
        : IRequest<Response<GetPurchaseOrdersResponse>>;
}
