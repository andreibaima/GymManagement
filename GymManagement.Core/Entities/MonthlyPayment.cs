using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.Entities
{
    public class MonthlyPayment : BaseEntity
    {
        public MonthlyPayment(double value, DateTime dueDate, string month, string registrationCode)
        {
            Value = value;
            BaseYear = DateTime.Now.Year.ToString();
            DueDate = dueDate;
            IsPay = false;
            Month = month;
            RegistrationCode = registrationCode;
        }

        protected MonthlyPayment()
        {

        }

        public double Value { get; private set; }
        public string BaseYear { get; private set; }
        public DateTime DueDate { get; set; }
        public DateTime? Payday { get; private set; }
        public bool IsPay { get; private set; }
        public string Month { get; private set; }
        public string RegistrationCode { get; private set; }
        [JsonIgnore]
        public Registration Registration { get; private set; }

        public void makePayment()
        {
            Payday = DateTime.Now;
            IsPay = true;
        }
    }
}
