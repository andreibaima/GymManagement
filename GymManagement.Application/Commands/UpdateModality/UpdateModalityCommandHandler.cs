using GymManagement.Core.Entities;
using GymManagement.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Commands.UpdateModality
{
    public class UpdateModalityCommandHandler : IRequestHandler<UpdateModalityCommand, Unit>
    {
        private readonly IModalityRepository _modalityRepository;

        public UpdateModalityCommandHandler(IModalityRepository modalityRepository)
        {
            _modalityRepository = modalityRepository;
        }

        public async Task<Unit> Handle(UpdateModalityCommand request, CancellationToken cancellationToken)
        {
            var modality = await _modalityRepository.GetByCodeAsync(request.Code);

            modality.Update(request.Description);

            if (request.Observation != null) modality.adicionarObservacao(request.Observation);

            await _modalityRepository.SalveChangesAsync();

            return Unit.Value;
        }
    }
}
