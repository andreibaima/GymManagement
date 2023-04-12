using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<Unit>
    {
        public DeleteStudentCommand(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
