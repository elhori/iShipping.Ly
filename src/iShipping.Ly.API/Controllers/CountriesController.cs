using iShipping.Ly.Application.Dtos;
using iShipping.Ly.Application.Dtos.Country;
using iShipping.Ly.Application.Resources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace iShipping.Ly.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Response<GetCountriesResponse>>> GetAsync([FromQuery] GetCountriesRequest request)
            => await _mediator.Send(request);

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountriesResponse>> GetAsync(int id)
            => await _mediator.Send(new GetCountryRequest(id));

        [HttpPost]
        public async Task<ActionResult<GetCountriesResponse>> PostAsync([FromBody] CreateCountryRequest request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return Problem(ExceptionMessages.CountryAlreadyExist);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<GetCountriesResponse>> PutAsync([FromBody] UpdateCountryRequest request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return Problem(ExceptionMessages.CountryNotFound);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _mediator.Send(new DeleteCountryRequest(id));

            if (!result)
                return Problem(ExceptionMessages.CountryNotFound);

            return Ok();
        }
    }
}
