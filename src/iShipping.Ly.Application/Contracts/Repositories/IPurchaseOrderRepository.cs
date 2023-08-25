using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.PurchaseOrder;
using iShipping.Ly.Domain.Entities;

namespace iShipping.Ly.Application.Contracts.Repositories
{
    public interface IPurchaseOrderRepository : IAsyncRepository<PurchaseOrder>
    {
        public Task<Response<GetPurchaseOrdersResponse>> GetResponseAsync(GetPurchaseOrdersRequest request, CancellationToken cancellationToken = default);
        public Task<Response<GetPurchaseOrdersResponse>> GetResponseAsync(GetCustomerPurchaseOrdersRequest request, CancellationToken cancellationToken = default);
    }
}
