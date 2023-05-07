using GymManagement.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.UpdatePlan
{
    public class UpdatePlanCommand : IRequest<Unit>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public double Valor { get; set; }
        public List<PlanModality> Modalities { get; set; }
    }
}
