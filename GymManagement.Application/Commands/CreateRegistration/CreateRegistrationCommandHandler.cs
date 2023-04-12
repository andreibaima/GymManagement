using GymManagement.Core.Entities;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.CreateRegistration
{
    public class CreateRegistrationCommandHandler : IRequestHandler<CreateRegistrationCommand, string>
    {
        private readonly IRegistrationRepository _registrationRepository;

        public CreateRegistrationCommandHandler(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<string> Handle(CreateRegistrationCommand request, CancellationToken cancellationToken)
        {
            string[] meses = { "JAN", "FEV", "MAR", "ABR", "MAI", "JUN", "JUL", "AGO", "SET", "OUT", "NOV", "DEZ" };
            List<MonthlyPayment> monthlyPayments = new List<MonthlyPayment>();

            for (var i = 1; i <= 12; i++)
            {
                if (i >= DateTime.Now.Month)
                {
                    var vencimento = new DateTime(DateTime.Now.Year, i, request.DueDate, 00, 00, 00);
                    var monthlyPayment = new MonthlyPayment(request.Valor, vencimento, meses[i - 1], request.Code);
                    monthlyPayments.Add(monthlyPayment);
                }
            }

            request.MonthlyPayments = monthlyPayments;


            var registration = new Registration(request.Code, request.StudentCode, request.PlanCode, request.Valor, request.DueDate, request.MonthlyPayments);

            await _registrationRepository.AddAsync(registration);
            await _registrationRepository.SalveChangesAsync();
            
            return registration.Code;
        }
    }
}
