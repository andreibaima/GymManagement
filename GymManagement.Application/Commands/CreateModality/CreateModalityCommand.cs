using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.CreateModality
{
    public class CreateModalityCommand : IRequest<string>
    {
        public CreateModalityCommand(string code, string description, string? observation)
        {
            Code = code;
            Description = description;
            Observation = observation;
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public string? Observation { get; set; }
    }
}
