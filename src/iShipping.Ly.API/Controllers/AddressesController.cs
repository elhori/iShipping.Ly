using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Address;
using iShipping.Ly.Application.Resources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iShipping.Ly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Response<GetAddressesResponse>>> GetAsync([FromQuery] GetAddressesRequest request)
            => await _mediator.Send(request);

        [HttpGet("{id}")]
        public async Task<ActionResult<GetAddressesResponse>> GetAsync(int id)
            => await _mediator.Send(new GetAddressRequest(Id: id));

        [HttpPost]
        public async Task<ActionResult<GetAddressesResponse>> PostAsync([FromBody] CreateAddressRequest request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return Problem(ExceptionMessages.AddressAlreadyExist);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<GetAddressesResponse>> PutAsync([FromBody] UpdateAddressRequest request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return Problem(ExceptionMessages.AddressNotFound);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync([FromBody] DeleteAddressRequest request)
        {
            var result = await _mediator.Send(request);

            if (!result)
                return Problem(ExceptionMessages.AddressNotFound);

            return Ok();
        }
    }
}
