using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.PurchaseOrder;
using MediatR;

namespace iShipping.Ly.Application.Handlers.PurchaseOrders
{
    public class GetPurchaseOrdersRequestHandler : IRequestHandler<GetPurchaseOrdersRequest, Response<GetPurchaseOrdersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPurchaseOrdersRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<GetPurchaseOrdersResponse>> Handle(GetPurchaseOrdersRequest request, CancellationToken cancellationToken)
            => await _unitOfWork.PurchaseOrders.GetResponseAsync(request, cancellationToken);
    }
}
