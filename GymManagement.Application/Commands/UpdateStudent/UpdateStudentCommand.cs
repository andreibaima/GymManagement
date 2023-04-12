using GymManagement.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<Unit>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; } //genero
        public string? Observation { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
    }
}
