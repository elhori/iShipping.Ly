using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.PurchaseOrder;
using MediatR;

namespace iShipping.Ly.Application.Handlers.PurchaseOrders
{
    public class DeletePurchaseOrderItemRequestHandler : IRequestHandler<DeletePurchaseOrderItemRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePurchaseOrderItemRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeletePurchaseOrderItemRequest request, CancellationToken cancellationToken)
        {
            var purchaseOrderItem = await _unitOfWork.PurchaseOrderItems.GetAsync(request.Id, cancellationToken);

            if (purchaseOrderItem == null)
            {
                return false;
            }

            await _unitOfWork.PurchaseOrderItems.RemoveAsync(purchaseOrderItem, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
