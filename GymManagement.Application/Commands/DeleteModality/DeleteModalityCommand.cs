using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.DeleteModality
{
    public class DeleteModalityCommand : IRequest<Unit>
    {
        public DeleteModalityCommand(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
