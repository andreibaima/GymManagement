using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByCodeAsync(request.Code);

            if (student == null) throw new Exception("O código do studante não existe");

            student.Update(request.Name, request.DateOfBirth, request.Gender, request.Contact, request.Address);

            if (request.Observation != null) student.adicionarObservacao(request.Observation);

            await _studentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
