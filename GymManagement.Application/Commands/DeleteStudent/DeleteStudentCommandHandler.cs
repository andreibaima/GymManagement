using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IMonthlyPayments _monthlyPayments;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository, IRegistrationRepository registrationRepository, IMonthlyPayments monthlyPayments)
        {
            _studentRepository = studentRepository;
            _registrationRepository = registrationRepository;
            _monthlyPayments = monthlyPayments;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByCodeAsync(request.Code);
            var registration = await _registrationRepository.GetByCodeStudentAsync(request.Code);

            if(registration != null)
            {
                var monthlyPayments = await _monthlyPayments.GetByCodeRegistrationAsync(registration.Code);
                var monthlyPaymentsDelete = monthlyPayments.Where(mp => mp.DueDate.Month >= DateTime.Now.Month && mp.DueDate.Year == DateTime.Now.Year && !mp.IsPay).ToList();

                if(monthlyPaymentsDelete.Count > 0) await _monthlyPayments.DeleteAsyncRange(monthlyPaymentsDelete);

                registration.inativarRegistro();
            }

            student.inativarAluno();
            
            await _studentRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
