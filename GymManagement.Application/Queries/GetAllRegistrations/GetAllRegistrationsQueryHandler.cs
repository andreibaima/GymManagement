using GymManagement.Application.ViewModels;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetAllRegistrations
{
    public class GetAllRegistrationsQueryHandler : IRequestHandler<GetAllRegistrationsQuery, List<RegistrationViewModel>>
    {
        private readonly IRegistrationRepository _registrationRepository;

        public GetAllRegistrationsQueryHandler(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        public async Task<List<RegistrationViewModel>> Handle(GetAllRegistrationsQuery request, CancellationToken cancellationToken)
        {
            var registros = await _registrationRepository.GetAllAsync();
            var registrationsViewModel = registros.Select(r => new RegistrationViewModel(r.Code, r.Student.Name, r.Plan.Description, r.Valor, r.DueDate)).ToList();


            return registrationsViewModel;
        }
    }
}
