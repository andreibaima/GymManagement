using GymManagement.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.CreatePlan
{
    public class CreatePlanCommand : IRequest<string>
    {
        public CreatePlanCommand(string code, string description, double valor, List<PlanModality> modalities)
        {
            Code = code;
            Description = description;
            Valor = valor;
            Modalities = modalities;
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public double Valor { get; set; }
        public List<PlanModality> Modalities { get; set; }
    }
}
