using GymManagement.Application.Commands.CreateStudent;
using GymManagement.Application.Commands.DeleteStudent;
using GymManagement.Application.Commands.UpdateStudent;
using GymManagement.Application.Queries.GetAllStudents;
using GymManagement.Application.Queries.GetStudentByCode;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.API.Controllers
{
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(students);
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var query = new GetStudentByCodeQuery(code);

            var student = await _mediator.Send(query);

            if (student == null) return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStudentCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetByCode), new {Code = id }, command);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> Put(string code, [FromBody] UpdateStudentCommand command)
        {

            var retorno = await _mediator.Send(command);

            if (retorno == null) return NotFound();
            //await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            var command = new DeleteStudentCommand(code);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
