using GymManagement.Application.Commands.CreateModality;
using GymManagement.Application.Commands.UpdateModality;
using GymManagement.Application.Commands.UpdateStudent;
using GymManagement.Application.Queries.GetAllModalities;
using GymManagement.Application.Queries.GetModalityByCode;
using GymManagement.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GymManagement.API.Controllers
{
    [Route("api/modalities")]
    public class ModalityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ModalityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var modalities = await _mediator.Send(new GetAllModalitiesQuery());
            return Ok(modalities);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var query = new GetModalityByCodeQuery(code);
            var modality = await _mediator.Send(query);

            if (modality == null) return NotFound();

            return Ok(modality);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateModalityCommand command)
        {
            var code = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetByCode), new { Code = code }, command);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Put(string code, [FromBody] UpdateModalityCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            return Ok();
        }
    }
}
