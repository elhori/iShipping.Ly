using iShipping.Ly.Application.Contracts.Repositories;
using iShipping.Ly.Application.Contracts.Services;
using iShipping.Ly.Application.Dtos.PurchaseOrder;
using iShipping.Ly.Application.Extensions;
using MediatR;

namespace iShipping.Ly.Application.Handlers.PurchaseOrders
{
    public class GetPurchaseOrderRequestHandler : IRequestHandler<GetPurchaseOrderRequest, GetPurchaseOrdersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public GetPurchaseOrderRequestHandler(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<GetPurchaseOrdersResponse> Handle(GetPurchaseOrderRequest request, CancellationToken cancellationToken)
        {
            var purchaseOrder = await _unitOfWork.PurchaseOrders.GetAsync(request.Id, cancellationToken);

            var customer = await _userService.GetUserAsync(purchaseOrder.CustomerId, cancellationToken);

            var response = purchaseOrder.ToResponse();

            response.CustomerName = $"{customer.FirstName} {customer.LastName}";

            return response;
        }
    }
}
