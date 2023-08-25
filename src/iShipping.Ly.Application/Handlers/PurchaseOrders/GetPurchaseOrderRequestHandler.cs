using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.PurchaseOrder;
using iShipping.Ly.Application.Extensions;
using MediatR;

namespace iShipping.Ly.Application.Handlers.PurchaseOrders
{
    public class GetPurchaseOrderRequestHandler : IRequestHandler<GetPurchaseOrderRequest, GetPurchaseOrdersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPurchaseOrderRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetPurchaseOrdersResponse> Handle(GetPurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            var purchaseOrder = await _unitOfWork.PurchaseOrders.GetAsync(request.Id, cancellationToken);

            var customer = await _unitOfWork.Users.GetUserAsync(purchaseOrder.CustomerId, cancellationToken);

            var response = purchaseOrder.ToResponse();

            response.CustomerName = $"{customer.FirstName} {customer.LastName}";

            return response;
        }
    }
}
