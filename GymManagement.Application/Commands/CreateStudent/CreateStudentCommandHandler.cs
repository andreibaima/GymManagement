using GymManagement.Core.Entities;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, string>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<string> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student(request.Code, request.Name, request.Cpf, request.Rg, request.DateOfBirth, request.Gender, request.Contact, request.Address);

            if (request.Observation != null) student.adicionarObservacao(request.Observation);

            student.ativarAluno();

            await _studentRepository.AddAsync(student);
            
            return student.Code;

        }
    }
}
