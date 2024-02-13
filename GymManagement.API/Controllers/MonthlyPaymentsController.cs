using GymManagement.Application.Commands.MakeThePayment;
using GymManagement.Application.Commands.UpdatePlan;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GymManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonthlyPaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MonthlyPaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPut("{id}/makePayments")]
        public async Task<IActionResult> makePayments(int id, [FromBody] MakeThePaymentCommand command)
        {
            var retorno = await _mediator.Send(command);

            if (retorno == null) return NotFound();

            return NoContent();
        }
    }
}
