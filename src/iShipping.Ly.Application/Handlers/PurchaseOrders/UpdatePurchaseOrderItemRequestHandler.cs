using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.PurchaseOrder;
using iShipping.Ly.Application.Extensions;
using MediatR;

namespace iShipping.Ly.Application.Handlers.PurchaseOrders
{
    public class UpdatePurchaseOrderItemRequestHandler
        : IRequestHandler<UpdatePurchaseOrderItemRequest, GetPurchaseOrderItemsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePurchaseOrderItemRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetPurchaseOrderItemsResponse> Handle(UpdatePurchaseOrderItemRequest request, CancellationToken cancellationToken)
        {
            var purchaseOrderItem = await _unitOfWork.PurchaseOrderItems.GetAsync(request.Id, cancellationToken);

            purchaseOrderItem.Update(request.ToModel());

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return purchaseOrderItem.ToResponse();
        }
    }
}
