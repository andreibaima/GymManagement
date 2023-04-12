using GymManagement.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetAllModalities
{
    public class GetAllModalitiesQuery : IRequest<List<ModalityViewModel>>
    {
        public GetAllModalitiesQuery()
        {

        }
    }
}
