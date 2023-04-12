using GymManagement.Application.ViewModels;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetStudentByCode
{
    public class GetStudentByCodeQueryHandler : IRequestHandler<GetStudentByCodeQuery, StudentViewModel>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentByCodeQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentViewModel> Handle(GetStudentByCodeQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByCodeAsync(request.Code);

            if (student == null) return null;

            var studentViewModel = new StudentViewModel(student.Code, student.Name, student.Cpf, student.Rg, student.DateOfBirth, student.IsActive, student.Contact);

            return studentViewModel;


        }
    }
}
