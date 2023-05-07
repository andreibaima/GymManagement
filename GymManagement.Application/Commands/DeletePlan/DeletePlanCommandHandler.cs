using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.DeletePlan
{
    public class DeletePlanCommandHandler : IRequestHandler<DeletePlanCommand, Unit>
    {
        private readonly IPlanRepository _planRepository;

        public DeletePlanCommandHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<Unit> Handle(DeletePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = await _planRepository.GetByCodeAsync(request.Code);

            if (plan == null) return Unit.Value;

            await _planRepository.DeletePlanAsync(plan);
            await _planRepository.SalveChangesAsync();


            return Unit.Value;
        }
    }
}
