using GymManagement.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetAllRegistrations
{
    public class GetAllRegistrationsQuery : IRequest<List<RegistrationViewModel>>
    {
        public GetAllRegistrationsQuery()
        {

        }
    }
}
