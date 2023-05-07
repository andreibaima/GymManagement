using GymManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.DTOs
{
    public class PlanDTO
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public double Valor { get; set; }
        public List<Modality> Modalities { get; set; }

        public static implicit operator PlanDTO(Plan v)
        {
            throw new NotImplementedException();
        }
    }
}
