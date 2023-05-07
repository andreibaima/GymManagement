using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Core.Entities
{
    public class Student : BaseEntity
    {
        public Student(string code, string name, string cpf, string rg, DateTime dateOfBirth, char gender, Contact contact, Address address)
        {
            Code = code;
            Name = name;
            Cpf = cpf;
            Rg = rg;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Contact = contact;
            Address = address;
        }

        protected Student()
        {

        }

        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public char Gender { get; private set; } //genero
        public string? Observation { get; private set; }
        public bool IsActive { get; private set; }
        public Contact Contact { get; private set; }
        public Address Address { get; private set; }
        [JsonIgnore]
        public List<Registration> Registration { get; private set; }

        public void adicionarObservacao(string obs)
        {
            Observation = obs;
        }

        public void inativarAluno()
        {
            IsActive = false;
        }

        public void ativarAluno()
        {
            IsActive = true;
        }

        public void Update(string name, DateTime dateOfBirth, char gender,  Contact contact, Address address)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Contact = contact;
            Address = address;
        }
    }
}
