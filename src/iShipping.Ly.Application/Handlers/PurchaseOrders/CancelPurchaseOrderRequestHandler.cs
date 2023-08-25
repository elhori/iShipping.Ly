using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.PurchaseOrder;
using iShipping.Ly.Domain.Enums;
using MediatR;

namespace iShipping.Ly.Application.Handlers.PurchaseOrders
{
    public class CancelPurchaseOrderRequestHandler : IRequestHandler<CancelPurchaseOrderRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CancelPurchaseOrderRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CancelPurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            var purchaseOrder = await _unitOfWork.PurchaseOrders.GetAsync(request.Id, cancellationToken);

            if (purchaseOrder == null)
            {
                return false;
            }

            purchaseOrder.UpdateStatus(PurchaseOrderStatus.Cancelled);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
