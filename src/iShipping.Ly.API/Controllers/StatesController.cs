using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.States;
using iShipping.Ly.Application.Resources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iShipping.Ly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Response<GetStatesResponse>>> GetAsync([FromQuery] GetStatesRequest request)
            => await _mediator.Send(request);

        [HttpGet("{id}")]
        public async Task<ActionResult<GetStatesResponse>> GetAsync(int id)
            => await _mediator.Send(new GetStateRequest(Id: id));

        [HttpPost]
        public async Task<ActionResult<GetStatesResponse>> PostAsync([FromBody] CreateStateRequest request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return Problem(ExceptionMessages.StateAlreadyExist);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<GetStatesResponse>> PutAsync([FromBody] UpdateStateRequest request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return Problem(ExceptionMessages.StateNotFound);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _mediator.Send(new DeleteStateRequest(Id: id));

            if (!result)
                return Problem(ExceptionMessages.StateNotFound);

            return Ok();
        }
    }
}
