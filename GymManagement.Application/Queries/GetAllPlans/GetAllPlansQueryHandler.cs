using GymManagement.Core.DTOs;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetAllPlans
{
    public class GetAllPlansQueryHandler : IRequestHandler<GetAllPlansQuery, List<PlanDTO>>
    {
        private readonly IPlanRepository _planRepository;

        public GetAllPlansQueryHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<List<PlanDTO>> Handle(GetAllPlansQuery request, CancellationToken cancellationToken)
        {
            return await _planRepository.GetAllAsync();
        }
    }
}
