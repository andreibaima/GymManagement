using GymManagement.Application.ViewModels;
using GymManagement.Core.Entities;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Queries.GetPlanByCode
{
    public class GetPlanByCodeQueryHandler : IRequestHandler<GetPlanByCodeQuery, PlanViewModel>
    {
        private readonly IPlanRepository _planRepository;

        public GetPlanByCodeQueryHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<PlanViewModel> Handle(GetPlanByCodeQuery request, CancellationToken cancellationToken)
        {
            var plaModalities = await _planRepository.GetPlanModalities(request.Code);

            var listModalities = plaModalities.Select(pm => pm.Modality).ToList();

            var plan = await _planRepository.GetByCodeAsync(request.Code);

            if (plan == null) return null;

            //var planViewModel = new PlanViewModel(plan.Code, plan.Description, plan.Valor, new List<Modality>());
            var planViewModel = new PlanViewModel(plan.Code, plan.Description, plan.Valor, listModalities);

            return planViewModel;
        }
    }
}
