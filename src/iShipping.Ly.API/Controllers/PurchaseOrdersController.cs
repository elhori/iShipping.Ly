using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.PurchaseOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace iShipping.Ly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PurchaseOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Response<GetPurchaseOrdersResponse>>> GetAsync([FromQuery] GetPurchaseOrdersRequest request)
            => await _mediator.Send(request);

        [HttpGet("customer-orders")]
        public async Task<ActionResult<Response<GetPurchaseOrdersResponse>>> GetAsync([FromQuery] GetCustomerPurchaseOrdersRequest request)
            => await _mediator.Send(request);

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPurchaseOrdersResponse>> GetAsync(int id)
            => await _mediator.Send(new GetPurchaseOrderRequest(Id: id));

        [HttpPost]
        public async Task<ActionResult<bool>> PostAsync(CreatePurchaseOrderRequest request)
        {
            request = request with { CustomerId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value };

            return await _mediator.Send(request);
        }

        [HttpPut("cancel")]
        public async Task<ActionResult<bool>> CancelAsync(CancelPurchaseOrderRequest request)
            => await _mediator.Send(request);

        [HttpPut("update-item")]
        public async Task<ActionResult<GetPurchaseOrderItemsResponse>> UpdateItemAsync(UpdatePurchaseOrderItemRequest request)
            => await _mediator.Send(request);

        [HttpDelete]
        public async Task<ActionResult<bool>> RemoveAsync(DeletePurchaseOrderItemRequest request)
            => await _mediator.Send(request);
    }
}
