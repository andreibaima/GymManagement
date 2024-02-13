using GymManagement.Application.ViewModels;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetAllPayments
{
    public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, List<PaymentsViewModel>>
    {
        private readonly IMonthlyPaymentsRepository _monthlyPaymentsRepository;

        public GetAllPaymentsQueryHandler(IMonthlyPaymentsRepository monthlyPaymentsRepository)
        {
            _monthlyPaymentsRepository = monthlyPaymentsRepository;
        }

        public async Task<List<PaymentsViewModel>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            var list = await _monthlyPaymentsRepository.GetAllAsync();

            List<PaymentsViewModel> listPaymentsViewModel = list.Select(mp => new PaymentsViewModel(
                        mp.Value, mp.BaseYear, mp.DueDate, mp.Payday, mp.IsPay, mp.Month, mp.RegistrationCode, mp.Registration.StudentCode, mp.Registration.Student.Name)).ToList();
            
            return listPaymentsViewModel;
        }
    }
}
