using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.ViewModels
{
    public class RegistrationViewModel
    {
        public RegistrationViewModel(string codeRegistration, string nameStudent, string namePlan, double valorPlan, int dueDate)
        {
            CodeRegistration = codeRegistration;
            NameStudent = nameStudent;
            NamePlan = namePlan;
            ValorPlan = valorPlan;
            DueDate = dueDate;
        }

        public string CodeRegistration { get; private set; }
        public string NameStudent { get; private set; }
        public string NamePlan { get; private set; }
        public double ValorPlan { get; private set; }
        public int DueDate { get; private set; }
    }
}
