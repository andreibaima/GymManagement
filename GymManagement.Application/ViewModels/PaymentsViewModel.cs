using GymManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.ViewModels
{
    public class PaymentsViewModel
    {
        public PaymentsViewModel(double value, string baseYear, DateTime dueDate, DateTime? payday, bool isPay, string month, string registrationCode, string stutendCode, string studendName)
        {
            Value = value;
            BaseYear = baseYear;
            DueDate = dueDate;
            Payday = payday;
            IsPay = isPay;
            Month = month;
            RegistrationCode = registrationCode;
            StutendCode = stutendCode;
            StudendName = studendName;
        }

        public double Value { get; private set; }
        public string BaseYear { get; private set; }
        public DateTime DueDate { get; set; }
        public DateTime? Payday { get; private set; }
        public bool IsPay { get; private set; }
        public string Month { get; private set; }
        public string RegistrationCode { get; private set; }
        public string StutendCode { get; private set; }
        public string StudendName { get; private set; }
    }
}
