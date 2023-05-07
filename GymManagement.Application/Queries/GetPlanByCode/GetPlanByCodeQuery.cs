using GymManagement.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetPlanByCode
{
    public class GetPlanByCodeQuery : IRequest<PlanViewModel>
    {
        public GetPlanByCodeQuery(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
