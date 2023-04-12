using GymManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.ViewModels
{
    public class StudentViewModel
    {
        public StudentViewModel(string code, string name, string cpf, string rg, DateTime dateOfBirth, bool isActive, Contact contact)
        {
            Code = code;
            Name = name;
            Cpf = cpf;
            Rg = rg;
            DateOfBirth = dateOfBirth;
            IsActive = isActive;
            Contact = contact;
        }

        public string Code { get;  set; }
        public string Name { get;  set; }
        public string Cpf { get;  set; }
        public string Rg { get;  set; }
        public DateTime DateOfBirth { get;  set; }
        public bool IsActive { get;  set; }
        public Contact Contact { get;  set; }
    }
}
