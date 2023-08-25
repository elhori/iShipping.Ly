using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.PurchaseOrder;
using MediatR;

namespace iShipping.Ly.Application.Handlers.PurchaseOrders
{
    public class GetCustomerPurchaseOrdersRequestHandler
        : IRequestHandler<GetCustomerPurchaseOrdersRequest, Response<GetPurchaseOrdersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerPurchaseOrdersRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<GetPurchaseOrdersResponse>> Handle(GetCustomerPurchaseOrdersRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.PurchaseOrders.GetResponseAsync(request, cancellationToken);
    }
}
