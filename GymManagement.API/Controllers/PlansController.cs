using GymManagement.Application.Commands.CreatePlan;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.API.Controllers
{
    [Route("api/plans")]
    public class PlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostPlan([FromBody] CreatePlanCommand command){

            var code = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByCode), new { Code = code }, command);
        }

    }
}
