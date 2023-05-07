using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.UpdatePlan
{
    public class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand, Unit>
    {
        private readonly IPlanRepository _planRepository;

        public UpdatePlanCommandHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<Unit> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = await _planRepository.GetByCodeAsync(request.Code);

            if (plan == null) throw new Exception("Plano não encontrado");

            var planModalities = await _planRepository.GetPlanModalities(plan.Code);

            if (planModalities != null) await _planRepository.DeletePlanModalities(planModalities);


            plan.Update(request.Description, request.Valor, request.Modalities);

            await _planRepository.SalveChangesAsync();

            return Unit.Value;
        }
    }
}
