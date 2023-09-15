using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Dtos.PurchaseOrder;
using iShipping.Ly.Application.Extensions;
using iShipping.Ly.Domain.Entities;
using MediatR;

namespace iShipping.Ly.Application.Handlers.PurchaseOrders
{
    public class CreatePurchaseOrderRequestHandler : IRequestHandler<CreatePurchaseOrderRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePurchaseOrderRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreatePurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            var purchaseOrder = new PurchaseOrder(request.ToModel());

            var purchaseOrderItems = request.Items.Select(item => new PurchaseOrderItem(item.ToModel())).ToList();

            purchaseOrder.CalculateOrderPrice(purchaseOrderItems.Sum(p => p.TotalPrice));

            await _unitOfWork.PurchaseOrders.AddAsync(purchaseOrder);
            await _unitOfWork.PurchaseOrderItems.AddRangeAync(purchaseOrderItems);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
