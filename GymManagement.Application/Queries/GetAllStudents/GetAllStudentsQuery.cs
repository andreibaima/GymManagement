using GymManagement.Application.ViewModels;
using GymManagement.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<List<StudentViewModel>>
    {
        public GetAllStudentsQuery()
        {

        }
    }
}
