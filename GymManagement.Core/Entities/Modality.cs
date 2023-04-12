using Newtonsoft.Json;

namespace GymManagement.Core.Entities
{
    public class Modality : BaseEntity
    {
        public Modality(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; private set; }
        public string Description { get; private set; }
        public string? Observation { get; private set; }
        [JsonIgnore]
        public List<PlanModality> Plans { get; private set; }

        public void adicionarObservacao(string obs)
        {
            Observation = obs;
        }

        public void Update(string description)
        {
            Description = description;
        }
    }
}
