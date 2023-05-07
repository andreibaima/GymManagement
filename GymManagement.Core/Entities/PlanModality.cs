using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.Entities
{
    public class PlanModality : BaseEntity
    {
        public PlanModality(string plancode, string modalityCode)
        {
            Plancode = plancode;
            ModalityCode = modalityCode;
        }

        public string Plancode { get; private set; }
        //[JsonIgnore]
        public Plan Plan { get; private set; }
        public string ModalityCode { get; private set; }
        //[JsonIgnore]
        public Modality Modality { get; private set; }
    }
}
