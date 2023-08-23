using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.City;
using iShipping.Ly.Application.Resources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iShipping.Ly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Response<GetCitiesResponse>>> GetAsync([FromQuery] GetCitiesRequest request)
            => await _mediator.Send(request);

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCitiesResponse>> GetAsync(int id)
            => await _mediator.Send(new GetCityRequest(Id: id));

        [HttpPost]
        public async Task<ActionResult<GetCitiesResponse>> PostAsync([FromBody] CreateCityRequest request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return Problem(ExceptionMessages.CityAlreadyExist);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<GetCitiesResponse>> PutAsync([FromBody] UpdateCityRequest request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return Problem(ExceptionMessages.CityNotFound);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _mediator.Send(new DeleteCityRequest(Id: id));

            if (!result)
                return Problem(ExceptionMessages.CityNotFound);

            return Ok();
        }
    }
}
