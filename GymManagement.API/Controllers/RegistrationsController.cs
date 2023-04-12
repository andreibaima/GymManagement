using GymManagement.Application.Commands.CreateRegistration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.API.Controllers
{
    [Route("api/registrations")]
    public class RegistrationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistrationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRegistrationCommand command)
        {
            var code = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByCode), new {Code = code}, command);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            return Ok();
        }
    }
}
