using GymManagement.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetAllPlans
{
    public class GetAllPlansQuery : IRequest<List<PlanDTO>>
    {
    }
}
