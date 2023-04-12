using GymManagement.Core.Entities;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.CreatePlan
{
    public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, string>
    {
        private readonly IPlanRepository _planRepository;

        public CreatePlanCommandHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<string> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = new Plan(request.Code, request.Description, request.Valor, request.Modalities);

            await _planRepository.AddAsync(plan);
            await _planRepository.SalveChangesAsync();

            return plan.Code;
        }
    }
}
