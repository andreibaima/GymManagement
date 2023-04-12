using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.Entities
{
    public class Plan : BaseEntity
    {
        public Plan(string code, string description, double valor, List<PlanModality> modalities)
        {
            Code = code;
            Description = description;
            Valor = valor;
            Modalities = modalities;
            //Modalities = new List<PlanModality>();
        }

        protected Plan()
        {

        }

        public string Code { get; private set; }
        public string Description { get; private set; }
        public double Valor { get; private set; }
        public List<PlanModality> Modalities { get; private set; }
        public List<Registration> Registrations { get; set; }
    }
}
