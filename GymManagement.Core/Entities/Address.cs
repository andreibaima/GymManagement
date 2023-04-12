using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.Entities
{
    public class Address : BaseEntity
    {
        public Address(string zipCode, string publicPlace, string number, string neighborhood, string location, string uF, string studentCode)
        {
            ZipCode = zipCode;
            PublicPlace = publicPlace;
            Number = number;
            Neighborhood = neighborhood;
            Location = location;
            UF = uF;
            StudentCode = studentCode;
        }

        public string ZipCode { get; private set; } // Cep
        public string PublicPlace { get; private set; } //logradouro
        public string Number { get; private set; }
        public string Neighborhood { get; private set; } //Bairro
        public string Location { get; private set; }
        public string UF { get; set; }
        public string StudentCode { get; private set; }
        [JsonIgnore]
        public Student Student { get; private set; }
    }
}
