using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.UpdateModality
{
    public class UpdateModalityCommand : IRequest<Unit>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string? Observation { get; set; }
    }
}
