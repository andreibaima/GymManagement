using GymManagement.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.CreateRegistration
{
    public class CreateRegistrationCommand : IRequest<string>
    {
        public CreateRegistrationCommand(string code, string studentCode, string planCode, double valor, int dueDate)
        {
            Code = code;
            StudentCode = studentCode;
            PlanCode = planCode;
            Valor = valor;
            CreationDate = DateTime.Now;
            DueDate = dueDate;
            MonthlyPayments = new List<MonthlyPayment>();
        }
        public string Code { get; set; }
        public string StudentCode { get; set; }
        public string PlanCode { get; set; }
        public double Valor { get; set; }
        public DateTime CreationDate { get; set; }
        public int DueDate { get; set; }
        public string? Observation { get; set; }
        public List<MonthlyPayment> MonthlyPayments { get; set; }
    }
}
