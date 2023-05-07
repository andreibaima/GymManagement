using GymManagement.Application.Commands.CreatePlan;
using GymManagement.Application.Commands.DeletePlan;
using GymManagement.Application.Commands.UpdatePlan;
using GymManagement.Application.Commands.UpdateStudent;
using GymManagement.Application.Queries.GetAllPlans;
using GymManagement.Application.Queries.GetPlanByCode;
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllPlansQuery();

            var plans = await _mediator.Send(query);

            return Ok(plans);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var query = new GetPlanByCodeQuery(code);

            var plan = await _mediator.Send(query);

            if (plan == null) return NotFound();

            return Ok(plan);
        }

        [HttpPost]
        public async Task<IActionResult> PostPlan([FromBody] CreatePlanCommand command){

            var code = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByCode), new { Code = code }, command);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Put(string code, [FromBody] UpdatePlanCommand command)
        {

            var retorno = await _mediator.Send(command);

            if (retorno == null) return NotFound();
            //await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {

            var command = new DeletePlanCommand(code);

            await _mediator.Send(command);

            return NoContent();

        }

    }
}
