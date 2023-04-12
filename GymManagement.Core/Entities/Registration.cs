using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.Entities
{
    public class Registration : BaseEntity
    {
        public Registration(string code, string studentCode, string planCode, double valor, int dueDate, List<MonthlyPayment> monthlyPayments)
        {
            Code = code;
            StudentCode = studentCode;
            PlanCode = planCode;
            Valor = valor;
            CreationDate = DateTime.Now;
            DueDate = dueDate;

            MonthlyPayments = monthlyPayments;
        }

        protected Registration()
        {
           
        }

        public string Code { get; private set; }
        public string StudentCode { get; private set; }
        public Student Student { get; private set; }
        public string PlanCode { get; private set; }
        public Plan Plan { get; private set; }
        public double Valor { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int DueDate { get; set; }
        public string? Observation { get; private set; }
        public List<MonthlyPayment> MonthlyPayments { get; private set; }

    }
}
