using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.Entities
{
    public class Contact : BaseEntity
    {
        public Contact(string fone, string email, string studentCode)
        {
            Fone = fone;
            Email = email;
            StudentCode = studentCode;
        }

        public string Fone { get; private set; }
        public string Email { get; private set; }
        public string StudentCode { get; private set; }
        [JsonIgnore]
        public Student Student { get; private set; }
    }
}
