using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.DeletePlan
{
    public class DeletePlanCommand : IRequest<Unit>
    {
        public DeletePlanCommand(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
