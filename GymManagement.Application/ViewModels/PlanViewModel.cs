using GymManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.ViewModels
{
    public class PlanViewModel
    {
        public PlanViewModel(string code, string description, double valor, List<Modality> modalities)
        {
            Code = code;
            Description = description;
            Valor = valor;
            Modalities = modalities;
        }

        public string Code { get; set; }
        public string Description { get; set; }
        public double Valor { get; set; }
        public List<Modality> Modalities { get; set; }
    }
}
